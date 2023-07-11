window.onload=function(){
    //評價估算
    var Rating = 3997;
    var NumberTotal = 996;
    $(".star").children().eq(Math.round(Rating / NumberTotal) - 1).prop('checked', true)
    $("#NumberOrder").text(NumberTotal)

    //更新日期設定
    Now = $(".update").text(NowTime())
}

//#region 現在時間的方法
function NowTime(){
    var NowDate = new Date();
    var Now = `${NowDate.getFullYear()}年${(NowDate.getMonth()+1)<10?'0'+(NowDate.getMonth()+1):(NowDate.getMonth()+1)}月${NowDate.getDate()<10?'0'+NowDate.getDate():NowDate.getDate()}日 ${NowDate.getHours()<10?'0'+NowDate.getHours():NowDate.getHours()}:${NowDate.getMinutes()<10?'0'+NowDate.getMinutes():NowDate.getMinutes()}:${NowDate.getSeconds()<10?'0'+NowDate.getSeconds():NowDate.getSeconds()}`
    return Now
}
//#endregion 回傳字串

//放外面，定義重整事件
function refresh(){
    let Now = NowTime() 
    alert(Now)
    Now = $(".update").text(Now)
}


