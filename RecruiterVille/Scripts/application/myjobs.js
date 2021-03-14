function getjobslist() {
    showloading();
    $('#uljobs li').remove();

    $.ajax({
        type: "GET",
        url: "/job/getjobslist",
        dataType: "json",
        success: function (data) {
            var ishavingjobs = true;

            if (data != null) {
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        var tr = $('<li />');

                        $(tr).append('<a href="javascript:void(0);" onclick="openjob(this)"><i class="fa fa-suitcase"></i><input type="hidden" id="hiddenlistjobid" value="' + data[i].JobId + '" /> ' + data[i].JobTitle + '</a>');

                        //var tr = $('<tr />');
                        //var pay = '';
                        //var duration = '';
                        //var experience = '';

                        //if (data[i].MinPayRate > 0 || data[i].MaxPayRate > 0) {
                        //    pay = data[i].PayCurrencySign + ' ' + data[i].MinPayRate + ' - ' + data[i].MaxPayRate + '/' + data[i].PayTypeName;
                        //}

                        //if (data[i].JobDuration > 0) {
                        //    duration = data[i].JobDuration + ' ' + data[i].JobDurationTypeName;
                        //}

                        //if (data[i].MinExp > 0 && data[i].MaxExp > 0) {
                        //    experience = data[i].MinExp + ' - ' + data[i].MaxExp + ' Yrs';
                        //}
                        //else if (data[i].MinExp > 0) {
                        //    experience = data[i].MinExp + ' Yrs';
                        //}
                        //else if (data[i].MaxExp > 0) {
                        //    experience = data[i].MaxExp + ' Yrs';
                        //}

                        //$(tr).append('<td>' + (i + 1) + '<input type="hidden" id="hiddenjobid" value="' + data[i].JobId + '" /></td>' +
                        //            '<td><a href="/job/editjob/' + data[i].JobId + '" id="aeditjob"> <i class="fa fa-pencil"></i> Edit</a> &nbsp; <a href="javascript:void(0)" id="achangejobstatus" onclick="changejobstatus(this)"><i class="fa fa-trash-o"></i> Change Status</a>' +
                        //            ' &nbsp; <a href="/job/viewjob/' + data[i].JobId + '" id="aviewjob"><i class="fa fa-eye"></i> View</a>' +
                        //            ' &nbsp; <a href="javascript:void(0)" id="asharejob" onclick="sharejobthroughemail(this)"><i class="fa fa-envelope"></i> Email</a></td>' +
                        //            '<td>' + data[i].JobTitle + '</td>' +
                        //            '<td>' + data[i].CompanyJobId + '</td>' +
                        //            '<td>' + pay + '</td>' +
                        //            '<td>' + duration + '</td>' +
                        //            '<td>' + experience + '</td>' +
                        //            '<td>' + data[i].IndustryName + '</td>' +
                        //            '<td>' + data[i].TechnologyNames + '</td>' +
                        //            '<td><input type="hidden" id="hiddenjobstatusid" value="' + data[i].JobStatusId + '" />' + data[i].JobStatusName + '</td>');

                        $('#uljobs').append(tr);
                    }
                    $($('#uljobs li')[0]).find("a")[0].click();
                    $('#divjobpanel').css("display", "block");
                    $('#divjobbuttons').css("display", "block");
                }
                else {
                    ishavingjobs = false;
                }
            }
            else {
                ishavingjobs = false;
            }

            if (!ishavingjobs) {
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
        url: "/job/getjobdetailsbyidforview",
        dataType: "json",
        success: function (data) {
            if (data != null) {
                $("#hiddenselectedjobid").val(jobid);

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

                //$("#imgjoblogo").attr("src", companylogo);
                $("#aeditjob").attr("href", "/job/editjob/" + jobid);
                $("#aviewjob").attr("href", "/job/viewjob/" + jobid);
                $("#jobtitle").html(data.JobTitle);
                //$("#companyname").html(data.CompanyName);
                $("#experience").html(experience);
                $("#package").html(pay);
                $("#location").html(location);
                $("#jobdescription").html(data.JobDescription);
                $("#hiddenjobstatusid").val(data.JobStatus);
                
            }

            hideloading();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
}

function sharejobthroughemail(obj) {
    //var jobid = $(obj).closest('tr').find('#hiddenjobid').val();
    //$("#hiddenselectedjobid").val(jobid);

    var jobid = $('#hiddenselectedjobid').val();

    $("#radioemailcandidate")[0].click();
    $("#radiotomatchedprofiles")[0].click();

    $("#textsendtoemailids").val("");

    $('#modalsendemail').modal();
}

function CheckEmailSendTo(obj) {
    if ($(obj).attr("value") == "candidate") {
        $("#divemailcandidate").css("display", "block");
        $("#divemailvendor").css("display", "none");
        $("#radiotomatchedprofiles")[0].click();
    }
    else {
        $("#divemailcandidate").css("display", "none");
        $("#divemailvendor").css("display", "block");
        $("#radiotomatchedvendors")[0].click();
    }
    $("#divsendtoemailids").css("display", "none");
}

function CheckCandidateEmail(obj) {
    if ($(obj).attr("value") == "matchedprofiles") {
        $("#divsendtoemailids").css("display", "none");
    }
    else {
        $("#divsendtoemailids").css("display", "block");
    }
    $("#textsendtoemailids").val("");
}

function CheckVendorEmail(obj) {
    if ($(obj).attr("value") == "matchedvendors") {
        $("#divsendtoemailids").css("display", "none");
    }
    else {
        $("#divsendtoemailids").css("display", "block");
    }
    $("#textsendtoemailids").val("");
}

function SendJobEmail() {
    hideallalerts();
    var jobid = $("#hiddenselectedjobid").val();
    var istocandidate = $("#radioemailcandidate").prop("checked");
    var istomatched = false;
    var emailids = "";
    var isvalid = true;

    if (istocandidate) {
        if ($("#radiotomatchedprofiles").prop("checked")) {
            istomatched = true;
        }
        else {
            if (validatetextbox($("#textsendtoemailids")) == false) {
                isvalid = false;
            }
            else {
                emailids = $("#textsendtoemailids").val();
            }
        }
    }
    else {
        if ($("#radiotomatchedvendors").prop("checked")) {
            istomatched = true;
        }
        else {
            if (validatetextbox($("#textsendtoemailids")) == false) {
                isvalid = false;
            }
            else {
                emailids = $("#textsendtoemailids").val().trim();
            }
        }
    }

    if (isvalid) {
        showloading();

        var input = [];
        input = {
            strJobId: jobid,
            IsToCandidate: istocandidate,
            IsToMatched: istomatched,
            EmailIds: emailids
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/job/sendjobemail",
            dataType: "json",
            success: function (data) {
                if (data.EmailIds != "") {
                    if (istomatched) {
                        showsuccessalert("Job emails sent to matched profiles");
                    }
                    else {
                        showsuccessalert("Job emails sent to entered emailids");
                    }
                }
                else {
                    showwarningalert("Oops!! No emailids found to send the email");
                }
                //$("#hiddenselectedjobid").val('0');
                $('#closemodalsendemail').click();
                hideloading();
            },
            error: function (xhr) {
                hideloading();
                showerroralert(xhr.responseText);
            }
        });
    }
}

function changejobstatus(obj) {
    //var jobid = $(obj).closest('tr').find('#hiddenjobid').val();
    // $("#hiddenselectedjobid").val(jobid);

    var jobid = $('#hiddenselectedjobid').val();
    var jobstatusid = $(obj).closest('li').find('#hiddenjobstatusid').val();
    
    $("#selectjobstatus").val('0');
    $("#textstatuscomments").val('');

    $('#selectjobstatus').find("option:gt(0)").remove();

    if (jobstatusid == "Draft") {
        var options = '<option value="1">Publish</option>' +
                '<option value="2">Close</option>' +
                '<option value="3">Hold</option>' +
                '<option value="4">Delete</option>';

        $("#selectjobstatus").append(options);
    }
    else if (jobstatusid == "Published") {
        var options = '<option value="2">Close</option>' +
                '<option value="3">Hold</option>' +
                '<option value="4">Delete</option>';

        $("#selectjobstatus").append(options);
    }
    else if (jobstatusid == "Closed") {
        var options = '<option value="4">Delete</option>';

        $("#selectjobstatus").append(options);
    }
    else if (jobstatusid == "On Hold") {
        var options = '<option value="1">Publish</option>' +
                '<option value="2">Close</option>' +
                '<option value="4">Delete</option>';

        $("#selectjobstatus").append(options);
    }

    $('#modalchangestatus').modal();
}

function changejobstatusconfirm() {
    hideallalerts();
    var jobid = $("#hiddenselectedjobid").val();
    var jobstatus = $("#selectjobstatus");
    var comments = $("#textstatuscomments");
    var isvalid = true;

    if (validatedropdown(jobstatus) == false) {
        isvalid = false;
    }
    if (validatetextbox(comments) == false) {
        isvalid = false;
    }

    if (jobid != "" && jobid != "0" && isvalid) {
        showloading();

        var input = [];
        input = {
            strJobId: jobid,
            JobStatusId: jobstatus.val(),
            Comments: comments.val().trim()
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/job/changejobstatus",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showsuccessalert(data.StatusMessage);
                    //$("#hiddenselectedjobid").val('0');
                    $('#closemodalchangestatus').click();
                    getjobslist();
                }
                else {
                    showwarningalert(data.StatusMessage);
                }
                hideloading();
            },
            error: function (xhr) {
                hideloading();
                showerroralert(xhr.responseText);
            }
        });
    }
}

function shareonfacebook() {
    var joburl = weburl + 'jobview/' + $('#hiddenselectedjobid').val();
    window.open('https://www.facebook.com/sharer.php?u=' + $.trim(joburl), 'sharer', 'toolbar=0, status=0, width=626, height=436'); return false;
}

function shareontwitter() {
    var joburl = weburl + 'jobview/' + $('#hiddenselectedjobid').val();
    var jobtitle = $('#jobtitle').html();
    window.open('https://twitter.com/intent/tweet?text=' + $.trim(jobtitle) + '&url=' + $.trim(joburl) + '&via=' + weburl, 'sharer', 'toolbar=0, status=0, width=626, height=436,name="twitter:image"'); return false;
}

function shareonlinkedin() {
    var joburl = weburl + 'jobview/' + $('#hiddenselectedjobid').val();
    var jobtitle = $('#jobtitle').html();
    window.open('https://www.linkedin.com/shareArticle?mini=true&url=' + $.trim(joburl) + '&title=' + jobtitle + '&source=' + weburl, 'sharer', 'toolbar=0, status=0, width=626, height=436'); return false;
}
