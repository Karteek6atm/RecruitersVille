function getjobslist() {
    showloading();
    $('#tbodyjobs tr').remove();

    $.ajax({
        type: "GET",
        url: "/job/getjobslist",
        dataType: "json",
        success: function (data) {
            var ishavingjobs = true;

            if (data != null) {
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        var tr = $('<tr />');
                        var pay = '';
                        var duration = '';
                        var experience = '';

                        if (data[i].MinPayRate > 0 || data[i].MaxPayRate > 0) {
                            pay = data[i].PayCurrencySign + ' ' + data[i].MinPayRate + ' - ' + data[i].MaxPayRate + '/' + data[i].PayTypeName;
                        }

                        if (data[i].JobDuration > 0) {
                            duration = data[i].JobDuration + ' ' + data[i].JobDurationTypeName;
                        }

                        if (data[i].MinExp > 0 && data[i].MaxExp > 0) {
                            experience = data[i].MinExp + ' - ' + data[i].MaxExp + ' Yrs';
                        }
                        else if (data[i].MinExp > 0) {
                            experience = data[i].MinExp + ' Yrs';
                        }
                        else if (data[i].MaxExp > 0) {
                            experience = data[i].MaxExp + ' Yrs';
                        }

                        $(tr).append('<td>' + (i + 1) + '<input type="hidden" id="hiddenjobid" value="' + data[i].JobId + '" /></td>' +
                                    '<td><a href="/job/editjob/' + data[i].JobId + '" id="aeditjob"> <i class="fa fa-pencil"></i> Edit</a> &nbsp; <a href="javascript:void(0)" id="achangejobstatus" onclick="changejobstatus(this)"><i class="fa fa-trash-o"></i> Change Status</a>' +
                                    ' &nbsp; <a href="/job/viewjob/' + data[i].JobId + '" id="aviewjob"><i class="fa fa-eye"></i> View</a>'+
                                    ' &nbsp; <a javascript:void(0)" id="asharejob" onclick="sharejobthroughemail(this)"><i class="fa fa-envelope"></i> Email</a></td>' +
                                    '<td>' + data[i].JobTitle + '</td>' +
                                    '<td>' + data[i].CompanyJobId + '</td>' +
                                    '<td>' + pay + '</td>' +
                                    '<td>' + duration + '</td>' +
                                    '<td>' + experience + '</td>' +
                                    '<td>' + data[i].IndustryName + '</td>' +
                                    '<td>' + data[i].TechnologyNames + '</td>' +
                                    '<td><input type="hidden" id="hiddenjobstatusid" value="' + data[i].JobStatusId + '" />' + data[i].JobStatusName + '</td>');

                        $('#tbodyjobs').append(tr);
                    }
                }
                else {
                    ishavingjobs = false;
                }
            }
            else {
                ishavingjobs = false;
            }

            if (!ishavingjobs) {
                var tr = '<tr />';
                $(tr).append('<td colspan="10">No jobs found.</td>');
                $('#tbodyjobs').append(tr);
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

}

function changejobstatus(obj) {
    var jobid = $(obj).closest('tr').find('#hiddenjobid').val();
    var jobstatusid = parseInt($(obj).closest('tr').find('#hiddenjobstatusid').val());
    $("#hiddenselectedjobid").val(jobid);

    $("#selectjobstatus").val('0');
    $("#textstatuscomments").val('');

    $('#selectjobstatus').find("option:gt(0)").remove();

    if (jobstatusid == 0) {
        var options = '<option value="1">Publish</option>' +
                '<option value="2">Close</option>' +
                '<option value="3">Hold</option>' +
                '<option value="4">Delete</option>';

        $("#selectjobstatus").append(options);
    }
    else if (jobstatusid == 1) {
        var options = '<option value="2">Close</option>' +
                '<option value="3">Hold</option>' +
                '<option value="4">Delete</option>';

        $("#selectjobstatus").append(options);
    }
    else if (jobstatusid == 2) {
        var options = '<option value="4">Delete</option>';

        $("#selectjobstatus").append(options);
    }
    else if (jobstatusid == 3) {
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
                    $("#hiddenselectedjobid").val('0');
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