function getLocations() {
    $.ajax({
        type: "GET",
        url: "/site/getlocations",
        dataType: "json",
        success: function (data) {
            if (data != null) {
                if (data.length > 0) {
                    var availableLocations = [];
                    for (var i = 0; i < data.length; i++) {
                        availableLocations.push(data[i].LocationName);
                    }

                    $("#textlocation").autocomplete({
                        source: availableLocations
                    });
                }
            }
            searchJobs();
        },
        error: function (xhr) {
            showerroralert(xhr.responseText);
        }
    });
}

var pagenumber = 1;
var pagesize = 10;

function searchJobs() {
    showloading();
    var skills = $('#textskills');
    var location = $('#textlocation');

    var input = [];
    input = {
        Skills: skills.val().trim(),
        Location: location.val().trim(),
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

                        if (data[i].MinPayRate > 0 || data[i].MaxPayRate > 0) {
                            pay = '<i class="fa fa-money"></i> ' + data[i].PayCurrencySign + ' ' + data[i].MinPayRate + ' - ' + data[i].MaxPayRate + ' </span>';
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

                        $(li).append('<div class="doctor-img clearfix"><img src="/images/logo-sample.png" alt="" title="" width="270" height="259"><input type="hidden" id="hiddenjobid" value="' + data[i].JobId + '" /></div>' +
                                    '<div class="doctor-list-con">' +
                                    '<h1><a target="_blank" href="/jobview/' + data[i].JobId + '">' + data[i].JobTitle + '</a></h1>' +
                                    '<h3>' + data[i].CompanyName + '</h3>' +
                                    '<p>' + data[i].TechnologyNames + '</p>' +
                                    '<div class="location-price docto-locatio"> <i class="fa fa-map-marker"></i> ' + data[i].JobLocation + '</div>' +
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