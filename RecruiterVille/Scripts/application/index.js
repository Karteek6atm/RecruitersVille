var Base64 = {
    _keyStr: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=",
    encode: function (input) {
        var output = "";
        var chr1, chr2, chr3, enc1, enc2, enc3, enc4;
        var i = 0;

        input = Base64._utf8_encode(input);

        while (i < input.length) {
            chr1 = input.charCodeAt(i++);
            chr2 = input.charCodeAt(i++);
            chr3 = input.charCodeAt(i++);

            enc1 = chr1 >> 2;
            enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
            enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
            enc4 = chr3 & 63;

            if (isNaN(chr2)) {
                enc3 = enc4 = 64;
            }
            else if (isNaN(chr3)) {
                enc4 = 64;
            }

            output = output + this._keyStr.charAt(enc1) + this._keyStr.charAt(enc2) + this._keyStr.charAt(enc3) + this._keyStr.charAt(enc4);
        }
        return output;
    },
    decode: function (input) {
        var output = "";
        var chr1, chr2, chr3;
        var enc1, enc2, enc3, enc4;
        var i = 0;

        input = input.replace(/[^A-Za-z0-9\+\/\=]/g, "");

        while (i < input.length) {
            enc1 = this._keyStr.indexOf(input.charAt(i++));
            enc2 = this._keyStr.indexOf(input.charAt(i++));
            enc3 = this._keyStr.indexOf(input.charAt(i++));
            enc4 = this._keyStr.indexOf(input.charAt(i++));

            chr1 = (enc1 << 2) | (enc2 >> 4);
            chr2 = ((enc2 & 15) << 4) | (enc3 >> 2);
            chr3 = ((enc3 & 3) << 6) | enc4;

            output = output + String.fromCharCode(chr1);

            if (enc3 != 64) {
                output = output + String.fromCharCode(chr2);
            }
            if (enc4 != 64) {
                output = output + String.fromCharCode(chr3);
            }
        }

        output = Base64._utf8_decode(output);

        return output;
    },
    _utf8_encode: function (string) {
        string = string.replace(/\r\n/g, "\n");
        var utftext = "";

        for (var n = 0; n < string.length; n++) {
            var c = string.charCodeAt(n);

            if (c < 128) {
                utftext += String.fromCharCode(c);
            }
            else if ((c > 127) && (c < 2048)) {
                utftext += String.fromCharCode((c >> 6) | 192);
                utftext += String.fromCharCode((c & 63) | 128);
            }
            else {
                utftext += String.fromCharCode((c >> 12) | 224);
                utftext += String.fromCharCode(((c >> 6) & 63) | 128);
                utftext += String.fromCharCode((c & 63) | 128);
            }
        }
        return utftext;
    },
    _utf8_decode: function (utftext) {
        var string = "";
        var i = 0;
        var c = c1 = c2 = 0;

        while (i < utftext.length) {
            c = utftext.charCodeAt(i);

            if (c < 128) {
                string += String.fromCharCode(c);
                i++;
            }
            else if ((c > 191) && (c < 224)) {
                c2 = utftext.charCodeAt(i + 1);
                string += String.fromCharCode(((c & 31) << 6) | (c2 & 63));
                i += 2;
            }
            else {
                c2 = utftext.charCodeAt(i + 1);
                c3 = utftext.charCodeAt(i + 2);
                string += String.fromCharCode(((c & 15) << 12) | ((c2 & 63) << 6) | (c3 & 63));
                i += 3;
            }
        }
        return string;
    }
}

//var encode = document.getElementById('encode'),
//    decode = document.getElementById('decode'),
//    output = document.getElementById('output'),
//    input = document.getElementById('input');

//encode.onclick = function () {
//    output.innerHTML = Base64.encode(input.value);
//}

//decode.onclick = function () {
//    var $str = output.innerHTML;
//    output.innerHTML = Base64.decode($str);
//}

var pagenumber = 1;
var pagesize = 6;

function getjobs() {
    showloading();

    var input = [];
    input = {
        Skills: "",
        Location: "",
        PageNumber: pagenumber,
        PageSize: pagesize
    }

    $.ajax({
        type: "POST",
        data: (input),
        url: "/site/searchjobs",
        dataType: "json",
        success: function (data) {
            $('#uljobs li').remove();
            if (data != null) {
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        var li = $('<li />');
                        var experience = '';
                        var pay = '';
                        var location = '';
                        var companylogo = '/images/logo.jpg';

                        if (data[i].MinPayRate > 0 && data[i].MaxPayRate > 0) {
                            pay = '<i class="fa fa-money"></i> ' + data[i].PayCurrencySign + ' ' + data[i].MinPayRate + ' - ' + data[i].MaxPayRate + ' </span>';
                        }
                        else if (data[i].MinPayRate > 0) {
                            pay = '<i class="fa fa-money"></i> ' + data[i].PayCurrencySign + ' ' + data[i].MinPayRate + ' </span>';
                        }
                        else if (data[i].MaxPayRate > 0) {
                            pay = '<i class="fa fa-money"></i> ' + data[i].PayCurrencySign + ' ' + data[i].MaxPayRate + ' </span>';
                        }

                        if (data[i].MinExp > 0 && data[i].MaxExp > 0) {
                            experience = '<span><i class="fa fa-suitcase"></i> ' + data[i].MinExp + ' to ' + data[i].MaxExp + ' Yrs' + '</span> ';
                        }
                        else if (data[i].MinExp > 0) {
                            experience = '<span><i class="fa fa-suitcase"></i> ' + data[i].MinExp + ' Yrs' + '</span> ';
                        }
                        else if (data[i].MaxExp > 0) {
                            experience = '<span><i class="fa fa-suitcase"></i> ' + data[i].MaxExp + ' Yrs' + '</span> ';
                        }

                        if (data[i].CompanyLogo != "") {
                            companylogo = data[i].CompanyLogo;
                        }

                        if (data[i].JobLocation != "") {
                            location = '<i class="fa fa-map-marker"></i> ' + data[i].JobLocation + '';
                        }

                        $(li).append('<div class="doctor-img clearfix"><img src="' + companylogo + '" alt="" title="" ><input type="hidden" id="hiddenjobid" value="' + data[i].JobId + '" /></div>' +
                                    '<div class="doctor-list-con">' +
                                    '<h1><a target="_blank" href="/jobview/' + data[i].JobId + '">' + data[i].JobTitle + '</a></h1>' +
                                    '<h3>' + data[i].CompanyName + '</h3>' +
                                    '<p>' + data[i].TechnologyNames + '</p>' +
                                    '<div class="location-price docto-locatio">' + location + '</div>' +
                                    '<div class="location-price">' +
                                        '' + experience + ' ' + pay + '' +
                                    '</div>' +
                                    '</div>');

                        $('#uljobs').append(li);
                    }
                }
                else {
                    var li = $('<li />');
                    $(li).append('<div>' +
                                   'No Jobs found' +
                                   '</div>');

                    $('#uljobs').append(li);
                }
            }
            else {
                var li = $('<li />');
                $(li).append('<div>' +
                               'No Jobs found' +
                               '</div>');

                $('#uljobs').append(li);
            }
            hideloading();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
}

function getcount() {
    $.ajax({
        type: "GET",
        url: "/site/getwebdashboardcount",
        dataType: "json",
        success: function (data) {
            if (data != null) {
                $('#resumecount').html(data.Profiles);
                $('#companycount').html(data.Companies);
                $('#jobcount').html(data.Jobs);
            }
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
}