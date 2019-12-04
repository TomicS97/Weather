$(document).ready(function () {
    console.log("ready!");
});

$("#GetData").click(function () {
    var lat = $("#lat").val();
    var lon = $("#lan").val();
    GetData(lat, lon);
});

var GetData = function (lat, lon) {
    var url = '/Home/ReturnData';

    $.ajax({
        url: url,         
        data: { lat: lat, lon: lon },
        cache: false,
        success: function (data) {
            var myobj = JSON.parse(data);
            bindTable(myobj);
        }
    });
}
var bindTable = function (data) {
    $("#temperature").text(data.Temperature.Value);
    $("#devPoint").text(data.DewPoint.Value);
    $("#humidity").text(data.Humidity.Value);
    $("#fogValue").text(data.Fog.Percent + " % ");
    $("#lowCloudsValue").text(data.LowClouds.Percent + " % ");
    $("#MediumCloudsValue").text(data.MediumClouds.Percent + " % ");
    $("#HighCloudsValue").text(data.HighClouds.Percent + " % ");

    //todo: Fog
    if (data.Fog.Percent <= 20) {
        $('#fog').css("background-image", "url(https://cdn.britannica.com/76/179676-138-DF4D600A/Overview-fog-forms.jpg)");
    } else if (data.Fog.Percent >= 21 && data.Fog.Percent <= 50) {
        $('#fog').css("background-image", "url(https://d1ix0byejyn2u7.cloudfront.net/drive/images/uploads/headers/ws_cropper/1_0x0_790x520_0x520_misty_road_resized.jpg)");
    }
    else if (data.LowClouds.Percent >= 51) {
        $('#fog').css("background-image", "url(https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS7Jp_hGLva5AX35xWjkkqIIEz-x7CmDGkW8KmaeGFz_6do_kr3)");

    }


    //low clouds
    if (data.LowClouds.Percent <= 20) {
        $('#lowClouds').css("background-image", "url(https://assets.htvapps.com/assets/images/weather/clear_sm.7dd038b.jpg)");
    } else if (data.LowClouds.Percent >= 21 && data.LowClouds.Percent <= 50) {
        $('#lowClouds').css("background-image", "url(https://upload.wikimedia.org/wikipedia/commons/9/93/Fly00890_-_Flickr_-_NOAA_Photo_Library.jpg)");
    }
    else if (data.LowClouds.Percent >= 51) {
        $('#lowClouds').css("background-image", "url(https://ak8.picdn.net/shutterstock/videos/1008013408/thumb/1.jpg)");

    }
    //medium clouds
    if (data.MediumClouds.Percent <= 20) {
        $('#MediumClouds').css("background-image", "url(https://assets.htvapps.com/assets/images/weather/clear_sm.7dd038b.jpg)");
    } else if (data.MediumClouds.Percent >= 21 && data.MediumClouds.Percent <= 50) {
        $('#mediumClouds').css("background-image", "url(https://upload.wikimedia.org/wikipedia/commons/9/93/Fly00890_-_Flickr_-_NOAA_Photo_Library.jpg)");
    }
    else if (data.MediumClouds.Percent >= 51) {
        $('#mediumClouds').css("background-image", "url(https://ak8.picdn.net/shutterstock/videos/1008013408/thumb/1.jpg)");

    }
    //todo: High clouds
    if (data.HighClouds.Percent <= 20) {
        $('#HighClouds').css("background-image", "url(https://assets.htvapps.com/assets/images/weather/clear_sm.7dd038b.jpg)");
    } else if (data.HighClouds.Percent >= 21 && data.HighClouds.Percent <= 50) {
        $('#HighClouds').css("background-image", "url(https://upload.wikimedia.org/wikipedia/commons/9/93/Fly00890_-_Flickr_-_NOAA_Photo_Library.jpg)");
    }
    else if (data.HighClouds.Percent >= 51) {
        $('#HighClouds').css("background-image", "url(https://ak8.picdn.net/shutterstock/videos/1008013408/thumb/1.jpg)");

    }
}