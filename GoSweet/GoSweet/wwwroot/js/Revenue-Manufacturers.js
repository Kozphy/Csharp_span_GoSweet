window.onload =function () {

    //#region 宣告區
    //搜索日期參數
    var NowDate = new Date();
    var Start = "";
    var StartDate = new Date();
    var End = "";
    var EndDate = new Date();

    //圖表參數
    const ctx = $("#chart");
    var ChartType = "bar";
    var XaxisNameArray = [];
    var ChartLegend = "總額";
    var QuentityofXaxis = [];
    var color = ['rgba(195, 166, 160, 0.3)', 'rgba(161, 92, 56, 0.3)', 'rgba(255, 99, 132, 0.3)', 'rgba(255, 159, 64, 0.3)', 'rgba(255, 205, 86, 0.3)', 'rgba(75, 192, 192, 0.3)', 'rgba(54, 162, 235, 0.3)', 'rgba(153, 102, 255, 0.3)', 'rgba(201, 203, 207, 0.3)'];
    var ReportChart;
    var ascendingOrder = true;
    var AscendingOrder = true;
    //Json資料參數
    var JsonData;

    //#endregion

    //初期設定
    ChartSetting();

    //#region Datepicker上下限設定
    //今天
    let NowYear = NowDate.getFullYear();//獲得年
    let NowMonth = NowDate.getMonth() + 1;//獲得月
    let NowDay = NowDate.getDate();//獲得日
    //格式製作
    let NowDateString = `${NowYear}-${NowMonth < 10 ? '0' + NowMonth : NowMonth}-${NowDay < 10 ? '0' + NowDay : NowDay}`
    //Datepicker設定
    // $("input[name='EndDate']").attr('value', NowDateString)
    $("input[name='EndDate']").attr('max', NowDateString)
    $("input[name='StartDate']").attr('max', NowDateString)

    //三個月前
    NowDate.setMonth(NowDate.getMonth() - 3);
    let LastThreeMonthYear = NowDate.getFullYear();
    let LastThreeMonth = NowDate.getMonth() + 1;
    let LastThreeMonthDay = NowDate.getDate();
    //格式製作
    let LastThreeMonthDateString = `${LastThreeMonthYear}-${LastThreeMonth < 10 ? '0' + LastThreeMonth : LastThreeMonth}-${LastThreeMonthDay < 10 ? '0' + LastThreeMonthDay : LastThreeMonthDay}`

    // $("input[name='StartDate']").attr('value', LastThreeMonthDateString)
     $("input[name='StartDate']").attr('min', LastThreeMonthDateString)
    $("input[name='EndDate']").attr('min', LastThreeMonthDateString);
    //#endregion 日期設定區塊 

    //#region Datepicker搜索
    $("form button").on("click", function () {
        Start = $("input[name='StartDate']").val();
        StartDate = new Date(Start);
        End = $("input[name='EndDate']").val();
        EndDate = new Date(End);

        if (StartDate > EndDate) {
            this.type = "button";
            alert('起始日期不可以大於結束日期');
        } else {
            this.type = "submit";
            /*alert(`開始日期${Start}結束日期${End}`)*/
        }
    })
    //#endregion 注意日期格式

    //#region X軸圖表選擇按鈕
    $("[name='X-axis']").on('click', async function () {
        let Xaxis = $("[name='X-axis']:checked").val();
        let Yaxis = $("[name='Y-axis']:checked").val();
        await groupbysomething(JsonData, Xaxis, Yaxis);
        ReportChart = drewChart();

        await XListOrders(JsonData, Xaxis);
    })
    //#endregion 

    //#region Y軸圖表選擇按鈕
    $("[name='Y-axis']").on('click', async function () {
        let Xaxis = $("[name='X-axis']:checked").val();
        let Yaxis = $("[name='Y-axis']:checked").val();
        //圖表設定
        if (Yaxis == "total") {
            ChartLegend = "總額";
        } else {
            ChartLegend = "數量";
        }
        await groupbysomething(JsonData, Xaxis, Yaxis);
        ReportChart = drewChart();

        await YListOrders(JsonData, Yaxis)
    })
    //#endregion

    //#region 圖形選擇按鈕
    $("[name='Chart_type']").on('click', function () {
        ChartType = $("[name='Chart_type']:checked").val();

        //圖表更新
        ReportChart = drewChart();
    })

    //#endregion

    //#region 繪圖方法
    function drewChart() {

        //畫面清除
        if (ReportChart instanceof Chart) {
            ReportChart.destroy();
        }

        //資料設定
        let datagroup = [{
            label: ChartLegend,
            data: QuentityofXaxis,
            backgroundColor: color
        }];

        //圖表設定
        var ChartSet = {
            type: ChartType,
            data: {
                labels: XaxisNameArray,
                datasets: datagroup
            },
            options: {
                responsive: true,
                scales: {
                    y: {
                        beginAtZero: true
                    }
                },
                plugins: {
                    legend: {
                        labels: {
                            font: {
                                size: 20
                            }
                        }
                    }
                }
            }
        }

        //圖表繪製
        ReportChart = new Chart(ctx, ChartSet);
        return ReportChart;
    }
    //#endregion

    //#region 從後端拿資料的方法
    async function GetData() {
        return JsonData = await $.ajax({
            url: "/Firm/JsonData",
            success: function (item) {

                //全部列表
                $.each(item, function (Index, Data) {
                    $("#home tbody").append(
                        `
                            <tr>
                                <th scope="row">${Index + 1}</th>
                                <td class="RevenuepageTableData">${Data.orderDate}</td>
                                <td class="RevenuepageTableData">${Data.name}</td>
                                <td class="RevenuepageTableData">${Data.id}</td>
                                <td class="RevenuepageTableData">${Data.shipState}</td>
                                <td class="RevenuepageTableData">${Data.price}</td>
                                <td class="RevenuepageTableData">${Data.quentity}</td>
                                <td class="RevenuepageTableData">${Data.total}</td>
                            </tr>
                        `
                    )
                })
            }
        })
    }
    //#endregion 需要重新撰寫路徑

    //#region 歸類整理方法
    async function groupbysomething(Json, Target, sum) {
        var something = await Object.entries(Json.reduce(function (result, current) {
            result[current[Target]] = result[current[Target]] || [];
            result[current[Target]].push(current);
            return result;
        }, {})).map(([key, value]) => ({ name: key, children: value }));

        

        switch (sum) {
            case "price": {
                something = something.map(function (element) {
                    var totals = 0;
                    element.children.forEach(elements => {
                        totals = totals + elements.price;
                    });
                    return [element.name, totals]
                }).sort();
                break;
            }
            case "quentity": {
                something = something.map(function (element) {
                    var totals = 0;
                    element.children.forEach(elements => {
                        totals = totals + elements.quentity;
                    });
                    return [element.name, totals]
                }).sort();
                break;
            }
            case "total": {
                something = something.map(function (element) {
                    var totals = 0;
                    element.children.forEach(elements => {
                        totals = totals + elements.total;
                    });
                    return [element.name, totals]
                }).sort();
                break;
            }
            default: {
                something = something.map(element => [element.name, element.children.length]).sort();
            }

        }

        /*console.log(something)*/
        /*console.log(something.map(elements => elements[0]))*/
        XaxisNameArray = something.map(elements => elements[0])
        /*console.log(something.map(elements => elements[1]))*/
        QuentityofXaxis = something.map(elements => elements[1])
        return something
    }
    //#endregion

    //#region 初期設定方法
    async function ChartSetting() {
        var Xaxis = $("[name='X-axis']:checked").val();
        var Yaxis = $("[name='Y-axis']:checked").val();
        JsonData = await GetData();
        await groupbysomething(JsonData, "orderDate", "total")
        ReportChart = drewChart();
    }
    //#endregion

    //#region 排序設定-X軸
    async function XListOrders(Json, Target) {

        var something = await Object.entries(Json.reduce(function (result, current) {
            result[current[Target]] = result[current[Target]] || [];
            result[current[Target]].push(current);
            return result;
        }, {})).map(([key, value]) => ({ name: key, children: value }));

        if (ascendingOrder) {
            something = something.sort((x, y) => x.name.localeCompare(y.name));
        } else {
            something = something.sort((x, y) => y.name.localeCompare(x.name));
        }
        ascendingOrder = !ascendingOrder;
        $("#home tbody").empty();

        var Index = 1;
        something.forEach(function (element) {
            element.children.forEach(function (Data) {
                $("#home tbody").append(
                    `
                            <tr>
                                <th scope="row">${Index++}</th>
                                <td class="RevenuepageTableData">${Data.orderDate}</td>
                                <td class="RevenuepageTableData">${Data.name}</td>
                                <td class="RevenuepageTableData">${Data.id}</td>
                                <td class="RevenuepageTableData">${Data.shipState}</td>
                                <td class="RevenuepageTableData">${Data.price}</td>
                                <td class="RevenuepageTableData">${Data.quentity}</td>
                                <td class="RevenuepageTableData">${Data.total}</td>
                            </tr>
                    `
                )
            })
        })
    }
    //#endregion

    //#region 排序設定-Y軸
    async function YListOrders(Json, Target) {

        var something = await Object.entries(Json.reduce(function (result, current) {
            result[current[Target]] = result[current[Target]] || [];
            result[current[Target]].push(current);
            return result;
        }, {})).map(([key, value]) => ({ name: key, children: value }));

        if (AscendingOrder) {
            something = something.sort((x, y) => x.name-y.name);
        } else {
            something = something.sort((x, y) => y.name-x.name);
        }
        AscendingOrder = !AscendingOrder;
        $("#home tbody").empty();

        var Index = 1;
        something.forEach(function (element) {
            element.children.forEach(function (Data) {
                $("#home tbody").append(
                    `
                            <tr>
                                <th scope="row">${Index++}</th>
                                <td class="RevenuepageTableData">${Data.orderDate}</td>
                                <td class="RevenuepageTableData">${Data.name}</td>
                                <td class="RevenuepageTableData">${Data.id}</td>
                                <td class="RevenuepageTableData">${Data.shipState}</td>
                                <td class="RevenuepageTableData">${Data.price}</td>
                                <td class="RevenuepageTableData">${Data.quentity}</td>
                                <td class="RevenuepageTableData">${Data.total}</td>
                            </tr>
                    `
                )
            })
        })
    }
    //#endregion
}