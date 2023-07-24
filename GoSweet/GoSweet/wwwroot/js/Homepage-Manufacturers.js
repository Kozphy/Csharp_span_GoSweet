window.onload=function(){

    //評價估算
    var Rating = 0;
    var NumberTotal = 0;
    var RatingData = GetRatingData();

    //更新日期設定
    Now = $(".update").text(NowTime())

    //#region 接收RatingJson
    async function GetRatingData() {
        return JsonData = await $.ajax({
            url: "/Firm/RatingJson",
            dataType: "json",
            success: function (item) {
                Rating = item.ratingScore;
                NumberTotal = item.ratingQuentity;
                $(".star").children().eq(Math.round(Rating / NumberTotal) - 1).prop('checked', true)
                $("#NumberOrder").text(NumberTotal)
            },
            error: function (error) {
                Rating = 0;
                NumberTotal = error;
            }
        })
    }
    //#endregion 

}


//#region 現在時間的方法
function NowTime(){
    var NowDate = new Date();
    var Now = `${NowDate.getFullYear()}年${(NowDate.getMonth()+1)<10?'0'+(NowDate.getMonth()+1):(NowDate.getMonth()+1)}月${NowDate.getDate()<10?'0'+NowDate.getDate():NowDate.getDate()}日 ${NowDate.getHours()<10?'0'+NowDate.getHours():NowDate.getHours()}:${NowDate.getMinutes()<10?'0'+NowDate.getMinutes():NowDate.getMinutes()}:${NowDate.getSeconds()<10?'0'+NowDate.getSeconds():NowDate.getSeconds()}`
    return Now
}
//#endregion 回傳字串

//#region 定義重整事件
function refresh(){
    let Now = NowTime() 
    alert(Now)
    Now = $(".update").text(Now)
}
//#endregion 可以可慮跟NowTime整合


