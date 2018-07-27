function modalWindowShow(src, title, cancelFunc, showFunc) {
    loadComcdCookieAndRemoveOthers();
    src = src;
     if ($("#myWindowModal").attr("id") == null) {
        var html = "";
        html += "<div class=\"modal fade\" id=\"myWindowModal\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myModalLabel\" aria-hidden=\"true\"";
        html += " data-backdrop = \"static\"";
        html += " > ";
        html += "      <div id='myWindowModal-dialog' class=\"bizModal-dialog\" style=\"width:1030px;\"> ";
        html += "        <div class=\"modal-content\"> ";
        html += "          <div class=\"modal-header\"> ";
        html += "            <button type=\"button\" class=\"close small\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button> ";
        html += "            <h4 class=\"modal-title\" id=\"myModalLabel\">" + title + "<i class='fa fa-arrows'></i></h4> ";
        html += "          </div> ";
        html += "          <div id=\"myWindowModalBody\" class=\"modal-body\"> ";
        html += "            ... ";
        html += "          </div> ";
        html += "        </div>";
        html += "      </div>";
        html += "</div>";
        $("body").append(html);
    }

    var html = "";
    html += "<iframe frameborder='0' scrolling='no' width='100%' height='750px;' src='" + src + "'></iframe>";
    $('#myWindowModalBody').html(html);
    /*if (typeof showFunc == "function") {
        showFunc();
    }*/
    $('#myWindowModal').modal('show');
    $('#myWindowModal').unbind("shown.bs.modal");
    $('#myWindowModal').unbind("hidden.bs.modal");
    $('#myWindowModal').on('hidden.bs.modal', cancelFunc);
    $('#myWindowModal-dialog').draggable({
        handle: ".modal-header"
    });
    initModalLocation('myWindowModal-dialog');

}

function modalWindowShowMini(src, title, cancelFunc, showFunc) {

    loadComcdCookieAndRemoveOthers();
    src = getComcdUsridAddedSrc(src);

    if ($("#myWindowModalMini").attr("id") == null) {
        var html = "";
        html += "<div class=\"modal fade\" id=\"myWindowModalMini\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myModalLabel\" aria-hidden=\"true\"";
        html += " data-backdrop = \"static\"";
        html += " > ";
        html += "      <div id='myWindowModalMini-dialog' class=\"bizModal-dialog\" style=\"width:500px;\"> ";
        html += "        <div class=\"modal-content\"> ";
        html += "          <div class=\"modal-header\"> ";
        html += "            <button type=\"button\" class=\"close small\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button> ";
        html += "            <h4 class=\"modal-title\" id=\"myModalLabel\">" + title + "<i class='fa fa-arrows'></i></h4> ";
        html += "          </div> ";
        html += "          <div id=\"myWindowModalMiniBody\" class=\"modal-body\"> ";
        html += "            ... ";
        html += "          </div> ";
        html += "        </div>";
        html += "      </div>";
        html += "</div>";
        $("body").append(html);
    }

    var html = "";
    html += "<iframe frameborder='0' scrolling='no' width='100%' height='250px;' src='" + src + "'></iframe>";
    $('#myWindowModalMiniBody').html(html);
    /*if (typeof showFunc == "function") {
        showFunc();
    }*/
    $('#myWindowModalMini').modal('show');
    $('#myWindowModalMini').unbind("shown.bs.modal");
    $('#myWindowModalMini').unbind("hidden.bs.modal");
    $('#myWindowModalMini').on('hidden.bs.modal', cancelFunc);
    $('#myWindowModalMini-dialog').draggable();
    initModalLocation('myWindowModalMini-dialog');
}

function modalWindowShowConfrim(src, title, cancelFunc, showFunc) {

    loadComcdCookieAndRemoveOthers();
    src = getComcdUsridAddedSrc(src);

    if ($("#myWindowModalMini").attr("id") == null) {
        var html = "";
        html += "<div class=\"modal fade\" id=\"myWindowModalMini\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myModalLabel\" aria-hidden=\"true\"";
        html += " data-backdrop = \"static\"";
        html += " > ";
        html += "      <div id='myWindowModalMini-dialog' class=\"bizModal-dialog\" style=\"width:500px;\"> ";
        html += "        <div class=\"modal-content\"> ";
        html += "          <div class=\"modal-header\"> ";
        html += "            <button type=\"button\" class=\"close small\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button> ";
        html += "            <h4 class=\"modal-title\" id=\"myModalLabel\">" + title + "<i class='fa fa-arrows'></i></h4> ";
        html += "          </div> ";
        html += "          <div id=\"myWindowModalMiniBody\" class=\"modal-body\"> ";
        html += "            ... ";
        html += "          </div> ";
        html += "        </div>";
        html += "      </div>";
        html += "</div>";
        $("body").append(html);
    }

    var html = "";
    html += "<iframe frameborder='0' scrolling='no' width='100%' height='50px;' src='" + src + "'></iframe>";
    $('#myWindowModalMiniBody').html(html);
    /*if (typeof showFunc == "function") {
        showFunc();
    }*/
    $('#myWindowModalMini').modal('show');
    $('#myWindowModalMini').unbind("shown.bs.modal");
    $('#myWindowModalMini').unbind("hidden.bs.modal");
    $('#myWindowModalMini').on('hidden.bs.modal', cancelFunc);
    $('#myWindowModalMini-dialog').draggable();
    initModalLocation('myWindowModalMini-dialog');
}

function modalWindowShowMid(src, title, cancelFunc, showFunc) {

    loadComcdCookieAndRemoveOthers();
    src = getComcdUsridAddedSrc(src);

    if ($("#myWindowModalMid").attr("id") == null) {
        var html = "";
        html += "<div class=\"modal fade\" id=\"myWindowModalMid\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myModalLabel\" aria-hidden=\"true\"";
        html += " data-backdrop = \"static\"";
        html += " > ";
        html += "      <div id='myWindowModalMid-dialog' class=\"bizModal-dialog\" style=\"width:800px;\"> ";
        html += "        <div class=\"modal-content\"> ";
        html += "          <div class=\"modal-header\"> ";
        html += "            <button type=\"button\" class=\"close small\" data-dismiss=\"modal\" aria-hidden=\"true\">&times;</button> ";
        html += "            <h4 class=\"modal-title\" id=\"myModalLabel\">" + title + "<i class='fa fa-arrows'></i></h4> ";
        html += "          </div> ";
        html += "          <div id=\"myWindowModalMidBody\" class=\"modal-body\"> ";
        html += "            ... ";
        html += "          </div> ";
        html += "        </div>";
        html += "      </div>";
        html += "</div>";
        $("body").append(html);
    }

    var html = "";
    html += "<iframe frameborder='0' scrolling='no' width='100%' height='500px;' src='" + src + "'></iframe>";
    $('#myWindowModalMidBody').html(html);
    /*if (typeof showFunc == "function") {
        showFunc();
    }*/
    $('#myWindowModalMid').modal('show');
    $('#myWindowModalMid').unbind("shown.bs.modal");
    $('#myWindowModalMid').unbind("hidden.bs.modal");
    $('#myWindowModalMid').on('hidden.bs.modal', cancelFunc);
    $('#myWindowModalMid-dialog').draggable();
    initModalLocation('myWindowModalMid-dialog');
}

function loadComcdCookieAndRemoveOthers() {
    if (sessionStorage == null) {
        return;
    }
    //업체토큰을 세션스토리지에서 읽어 쿠키에 넣는다.
    if (document.cookie == "" || document.cookie == null) {
        //documnet.cookie가 미지원이면(IE에 localhost일때, return)
        return;
    }

    //_COMCD없으며, 주소창에서 comcd얻기
    var comcd = typeof _COMCD == "undefined" ? "" : _COMCD;

    if (comcd == null || comcd == "") {
        var r = new RegExp(/comcd=(.*?)&/);
        var matches = r.exec(location.href + "&");
        if (matches == null) {
            return;
        }
        if (matches.length > 0) {
            comcd = matches[1];
        }
    }
    if (comcd == "") {
        return;
    }

    //_USRID없으며, 주소창에서 usrid얻기
    var usrid = typeof _USRID == "undefined" ? "" : _USRID;
    if (usrid == null || usrid == "") {
        var r = new RegExp(/usrid=(.*?)&/);
        var matches = r.exec(location.href + "&");
        if (matches == null) {
            return;
        }
        if (matches.length > 0) {
            usrid = matches[1];
        }
    }
    if (usrid == "") {
        return;
    }

    //comcd + usrid쿠키가 없으면 sessionStorage에서 읽어서 쿠키에 넣기
    var token = sessionStorage.getItem(comcd + "_" + usrid + "_token");
    if (token == null) {
        return;
    }

    //comcd이외에 다른 쿠키삭제
    var cookieArr = document.cookie.split(';');
    for (var i = 0; i < cookieArr.length; i++) {
        var cookie = cookieArr[i];
        var cookieKey = "";
        var cookieVal = "";
        if (cookie.charAt(0) == ' ') {
            cookie = cookie.substring(1);
        }
        var tmp = cookie.split("=");
        cookieKey = tmp[0];
        if (cookieKey.indexOf("_token") > 0 && (cookieKey.indexOf(comcd + "_" + usrid + "_token") == -1)) {
            document.cookie = cookieKey + '=; path=/; expires=Thu, 01 Jan 1970 00:00:01 GMT;';
        }
    }

    var exdate = new Date(); exdate.setDate(exdate.getDate() + 30);
    document.cookie = comcd + "_" + usrid + "_token" + "=" + token + "; path=/; expires=" + exdate.toUTCString();
    document.cookie = comcd + "_token" + "=" + token + "; path=/; expires=" + exdate.toUTCString();
}

function getComcdUsridAddedSrc(src) {

    //_COMCD없으며, 주소창에서 comcd얻기
    var comcd = typeof _COMCD == "undefined" ? "" : _COMCD;
    if (comcd == null || comcd == "") {
        var r = new RegExp(/comcd=(.*?)&/);
        var matches = r.exec(location.href + "&");
        if (matches == null) {
            comcd = "";
        } else {
            if (matches.length > 0) {
                comcd = matches[1];
            }
        }
    }
    //_USRID없으며, 주소창에서 usrid얻기
    var usrid = typeof _USRID == "undefined" ? "" : _USRID;
    if (usrid == null || usrid == "") {
        var r = new RegExp(/usrid=(.*?)&/);
        var matches = r.exec(location.href + "&");
        if (matches == null) {
            usrid = "";
        } else {
            if (matches.length > 0) {
                usrid = matches[1];
            }
        }
    }
    if (src.indexOf("?") > -1) {
        src += "&";
    } else {
        src += "?";
    }
    src += "comcd=" + comcd;
    src += "&usrid=" + usrid;
    return src;
}


function initModalLocation(modalname) {
    $("#" + modalname)[0].style.top = "100px";
    $("#" + modalname)[0].style.left = "100px";

};

function closePopUp(popupWin) {
    var popupDocument = popupWin.document;

    //팝업창 부모의 iframe들
    var iframes = $(popupWin.parent.document).find('iframe');

    //현재팝업창의 iframe
    var myIframe = null;

    try {
        $.each(iframes, function (index) {
            if ($(this).get(0).contentDocument === popupDocument) {
                myIframe = this;
                return;
            }
        });
    } catch (e) { }

    //찾은 iframe의 부모의 부모 개체아래 close 버튼을 찾아 클릭해준다.
    if (myIframe != null) {
        $(myIframe) //iframe
            .parent() //myWindowModalBody
            .parent() //modal-content
            .find('.close').trigger("click");
        return;
    }
}