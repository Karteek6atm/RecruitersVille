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

function searchJobs() {
    showloading();
    var skills = $('#textskills');
    var location = $('#textlocation');

    var input = [];
    input = {
        Skills: skills.val().trim(),
        Location: location.val().trim(),
        PageNumber: 1,
        PageSize: 100
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
                        //var experience = '';
                        //var pay = '';
                        //var location = '';
                        //var companylogo = '/images/logo.jpg';

                        //if (data[i].MinPayRate > 0 && data[i].MaxPayRate > 0) {
                        //    pay = '<i class="fa fa-money"></i> ' + data[i].PayCurrencySign + ' ' + data[i].MinPayRate + ' - ' + data[i].MaxPayRate + ' </span>';
                        //}
                        //else if (data[i].MinPayRate > 0) {
                        //    pay = '<i class="fa fa-money"></i> ' + data[i].PayCurrencySign + ' ' + data[i].MinPayRate + ' </span>';
                        //}
                        //else if (data[i].MaxPayRate > 0) {
                        //    pay = '<i class="fa fa-money"></i> ' + data[i].PayCurrencySign + ' ' + data[i].MaxPayRate + ' </span>';
                        //}

                        //if (data[i].MinExp > 0 && data[i].MaxExp > 0) {
                        //    experience = '<span><i class="fa fa-suitcase"></i> ' + data[i].MinExp + ' to ' + data[i].MaxExp + ' Yrs' + '</span> ';
                        //}
                        //else if (data[i].MinExp > 0) {
                        //    experience = '<span><i class="fa fa-suitcase"></i> ' + data[i].MinExp + ' Yrs' + '</span> ';
                        //}
                        //else if (data[i].MaxExp > 0) {
                        //    experience = '<span><i class="fa fa-suitcase"></i> ' + data[i].MaxExp + ' Yrs' + '</span> ';
                        //}

                        //if (data[i].CompanyLogo != "") {
                        //    companylogo = data[i].CompanyLogo;
                        //}

                        //if (data[i].JobLocation != "") {
                        //    location = '<i class="fa fa-map-marker"></i> ' + data[i].JobLocation + '';
                        //}

                        //$(li).append('<div class="doctor-img clearfix"><img src="' + companylogo + '" alt="" title="" ><input type="hidden" id="hiddenjobid" value="' + data[i].JobId + '" /></div>' +
                        //            '<div class="doctor-list-con">' +
                        //            '<h1><a target="_blank" href="/jobview/' + data[i].JobId + '">' + data[i].JobTitle + '</a></h1>' +
                        //            '<h3>' + data[i].CompanyName + '</h3>' +
                        //            '<p>' + data[i].TechnologyNames + '</p>' +
                        //            '<div class="location-price docto-locatio">' + location + '</div>' +
                        //            '<div class="location-price">' +
                        //                '' + experience + ' ' + pay + '' +
                        //            '</div>' +
                        //            '</div>');

                        $(li).append('<a href="javascript:void(0);" onclick="openjob(this)"><i class="fa fa-suitcase"></i><input type="hidden" id="hiddenlistjobid" value="' + data[i].JobId + '" /> ' + data[i].JobTitle + '</a>');

                        $('#uljobs').append(li);
                    }
                    $($('#uljobs li')[0]).find("a")[0].click();
                    $('#divjobpanel').css("display", "block");
                    $('#divjobbuttons').css("display", "block");
                }
                else {
                    var li = $('<li />');
                    $(li).append('No Jobs found');
                    
                    $('#uljobs').append(li);
                    $('#divjobpanel').css("display", "none");
                    $('#divjobbuttons').css("display", "none");
                }
            }
            else {
                var li = $('<li />');
                $(li).append('No Jobs found');

                $('#uljobs').append(li);
                $('#divjobpanel').css("display", "none");
                $('#divjobbuttons').css("display", "none");
            }
            hideloading();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
}

function openjob(obj) {
    showloading();
    var jobid = $(obj).closest("li").find("#hiddenlistjobid").val();

    var input = [];
    input = {
        strJobId: jobid
    }

    $.ajax({
        type: "POST",
        data: (input),
        url: "/site/searchjobview",
        dataType: "json",
        success: function (data) {
            if (data != null) {                
                $("#hiddenjobid").val(data.JobId);

                var experience = '';
                var pay = '';
                var location = '';
                var companylogo = '/images/logo.jpg';

                if (data.MinPayRate > 0 && data.MaxPayRate > 0) {
                    pay = '<i class="fa fa-money"></i> ' + data.PayCurrencySign + ' ' + data.MinPayRate + ' - ' + data.MaxPayRate + ' </span>';
                }
                else if (data.MinPayRate > 0) {
                    pay = '<i class="fa fa-money"></i> ' + data.PayCurrencySign + ' ' + data.MinPayRate + ' </span>';
                }
                else if (data.MaxPayRate > 0) {
                    pay = '<i class="fa fa-money"></i> ' + data.PayCurrencySign + ' ' + data.MaxPayRate + ' </span>';
                }

                if (data.MinExp > 0 && data.MaxExp > 0) {
                    experience = '<span><i class="fa fa-suitcase"></i> ' + data.MinExp + ' to ' + data.MaxExp + ' Yrs' + '</span> ';
                }
                else if (data.MinExp > 0) {
                    experience = '<span><i class="fa fa-suitcase"></i> ' + data.MinExp + ' Yrs' + '</span> ';
                }
                else if (data.MaxExp > 0) {
                    experience = '<span><i class="fa fa-suitcase"></i> ' + data.MaxExp + ' Yrs' + '</span> ';
                }

                if (data.CompanyLogo != "") {
                    companylogo = data.CompanyLogo;
                }

                if (data.JobLocation != "") {
                    location = '<i class="fa fa-map-marker"></i> ' + data.JobLocation + '';
                }
                
                $("#imgjoblogo").attr("src",companylogo);
                $("#jobtitle").html(data.JobTitle);
                $("#companyname").html(data.CompanyName);
                $("#experience").html(experience);
                $("#package").html(pay);
                $("#location").html(location);
                $("#jobdescription").html(data.JobDescription);
            }

            hideloading();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
}

function applyjob() {
    var isvalid = true;
    var textfirstname = $('#textfirstname');
    var textlastname = $('#textlastname');
    var textemailid = $('#textemailid');
    var textcontact = $('#textcontact');
    var hiddenresumefile = $("#hiddenresumefile");

    if (validatetextbox(textfirstname) == false) {
        isvalid = false;
    }
    if (validateemailid(textemailid) == false) {
        isvalid = false;
    }
    if (validatephonenumber(textcontact) == false) {
        isvalid = false;
    }
    if (validatetextbox(hiddenresumefile) == false) {
        isvalid = false;
        alert("Please upload resume");
    }

    if (isvalid) {
        showloading();

        var input = [];
        input = {
            strJobId: $("#hiddenjobid").val(),
            FirstName: textfirstname.val().trim(),
            LastName: textlastname.val().trim(),
            EmailId: textemailid.val().trim(),
            ContactNumber: textcontact.val().trim(),
            ResumePath: hiddenresumefile.val()
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/site/applyjob",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showsuccessalert(data.StatusMessage);
                    $('#closemodalapplyjob').click();
                }
                else {
                    showwarningalert(data.StatusMessage);
                }
                hideloading();
            },
            error: function (xhr) {
                hideloading();
                showerroralert(xhr.responseText);
                $('#closemodalapplyjob').click();
            }
        });
    }
    else {
        return false;
    }
}

function uploadresume() {
    var fileresume = $('#fileresume');

    if (validatedocument(fileresume) == false) {
        return false;
    }
    else {
        var formdata = new FormData();
        var file = document.getElementById('fileresume').files[0]
        if (formdata) {
            formdata.append("file", file);
            $.ajax({
                url: "/profile/uploadresume",
                type: "POST",
                data: formdata,
                processData: false,
                contentType: false,
                success: function (data) {
                    $('#hiddenresumefile').val(data.resumepath);
                }
            });
        }
    }
}

function openapplyjobmodal() {
    $('#textfirstname').val('');
    $('#textlastname').val('');
    $('#textemailid').val('');
    $('#textcontact').val('');
    $('#hiddenresumefile').val('');
    $('#fileresume').val('')
    $('#textfirstname').closest('.form-group').removeClass("has-error");
    $('#textfirstname').closest('.form-group').removeClass("has-success");
    $('#textlastname').closest('.form-group').removeClass("has-error");
    $('#textlastname').closest('.form-group').removeClass("has-success");
    $('#textemailid').closest('.form-group').removeClass("has-error");
    $('#textemailid').closest('.form-group').removeClass("has-success");
    $('#textcontact').closest('.form-group').removeClass("has-error");
    $('#textcontact').closest('.form-group').removeClass("has-success");

    $('#modalapplyjob').modal();
}

function shareonfacebook() {
    var joburl = weburl + 'jobview/' + $('#hiddenjobid').val();
    window.open('https://www.facebook.com/sharer.php?u=' + $.trim(joburl), 'sharer', 'toolbar=0, status=0, width=626, height=436'); return false;
}

function shareontwitter() {
    var joburl = weburl + 'jobview/' + $('#hiddenjobid').val();
    var jobtitle = $('#jobtitle').html();
    window.open('https://twitter.com/share?text=' + $.trim(jobtitle) + '&url=' + $.trim(joburl), 'sharer', 'toolbar=0, status=0, width=626, height=436,name="twitter:image"'); return false;
}

function shareonlinkedin() {
    var joburl = weburl + 'jobview/' + $('#hiddenjobid').val();
    window.open('https://www.linkedin.com/cws/share?url=' + $.trim(joburl), 'sharer', 'toolbar=0, status=0, width=626, height=436'); return false;
}