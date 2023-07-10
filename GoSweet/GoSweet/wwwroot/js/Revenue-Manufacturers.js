window.onload=function(){
  
  //#region 宣告區
  const ctx = $('#chart');
  var ChartType = 'bar'
  var XaxisNameArray = ['1', '2', '3']
  var ChartLegend = '總額'
  var QuentityofXaxis = [20,30,40]
  var color = ['rgba(195, 166, 160, 0.3)', 'rgba(161, 92, 56, 0.3)', 'rgba(255, 99, 132, 0.3)', 'rgba(255, 159, 64, 0.3)', 'rgba(255, 205, 86, 0.3)', 'rgba(75, 192, 192, 0.3)', 'rgba(54, 162, 235, 0.3)', 'rgba(153, 102, 255, 0.3)', 'rgba(201, 203, 207, 0.3)']
  var datagroup = [{label:ChartLegend, data: QuentityofXaxis, backgroundColor: color}]
  var ReportChart = drewChart()
  //#endregion
  
  //#region 設定搜索終日為今天
  var NowDate = new Date()
  let Nowday = NowDate.getDate()
  let NowMonth = NowDate.getMonth()+1
  let NowYear = NowDate.getFullYear()
  if (Nowday<10){Nowday = '0'+ Nowday}
  if (NowMonth<10){NowMonth = '0'+ NowMonth}
  NowDate = NowYear+"-"+NowMonth+"-"+Nowday
  $("input[name='EndDate']").attr('value', NowDate)
  $("input[name='EndDate']").attr('max', NowDate)
  //#endregion 注意日期格式
  
  //#region 搜索日期
  $("form button").on("click", function(){
    var Start = $("input[name='StartDate']").val()
    var StartDate = new Date(Start)
    var End = $("input[name='EndDate']").val()
    var EndtDate = new Date(End)
    console.log([Start, End])
  })
  //#endregion 回傳日期(目前單一，想辦法傳兩個參數)
  
  //#region X軸圖表選擇按鈕
  $("[name='X-axis']").on('click', function(){
    var Xaxis = $("[name='X-axis']:checked").val();
    alert(Xaxis);
  })
  //#endregion 回傳字串
  
  //#region Y軸圖表選擇按鈕
  $("[name='Y-axis']").on('click', function(){
    var Yaxis = $("[name='Y-axis']:checked").val();
    alert(Yaxis);
  })
  //#endregion 回傳字串
  
  //#region 圖型選擇按鈕
  $("[name='Chart_type']").on('click', function(){
    ChartType = $("[name='Chart_type']:checked").val();
    alert(ChartType);
    
    // 圖表更新
    drewChart();
  })
  //#endregion 
  
  //#region 圖表重製方法
  function drewChart(){
    if (ReportChart instanceof Chart){
      ReportChart.destroy()
    }
    var ChartSet={
      type:ChartType,
      data:{
        labels:XaxisNameArray,
        datasets:datagroup
      },
      options:{
        responsive: true,
        scales:{
          y:{
            beginAtZero: true
          }
        }
      }
    }
    ReportChart = new Chart(ctx, ChartSet)
    return ReportChart
  }
  //#endregion 回傳圖表但不知道要做啥
  
  //圖表大小重新繪製-不是必須
  window.addEventListener('resize', function(){
    ReportChart.resize();
  });

}


