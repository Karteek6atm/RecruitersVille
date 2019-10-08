function GetJobsList() {
    showloading();
    $('#tbodyJobsList tr').remove();

    $.ajax({
        type: "GET",
        url: "/SuperUser/user/getjobslist",
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

                        var SatusChange = '';
                        if (data[i].JobStatusId == 1) {
                            SatusChange = '<a href="javascript:void(0)" id="achangejobstatus" onclick="ChangeStatus(this,5)"> Unpublish</a>';
                        }
                        else if (data[i].JobStatusId == 5) {
                            SatusChange = '<a href="javascript:void(0)" id="achangejobstatus" onclick="ChangeStatus(this,1)"> Publish</a>';
                        }

                        $(tr).append('<td>' + (i + 1) + '<input type="hidden" id="hiddenjobid" value="' + data[i].JobId + '" /></td>' +
                                    '<td>' + data[i].JobTitle + '</td>' +
                                    '<td>' + data[i].CompanyJobId + '</td>' +
                                    '<td>' + pay + '</td>' +
                                    '<td>' + duration + '</td>' +
                                    '<td>' + experience + '</td>' +
                                    '<td>' + data[i].IndustryName + '</td>' +
                                    '<td>' + data[i].TechnologyNames + '</td>' +
                                    '<td><input type="hidden" id="hiddenjobstatusid" value="' + data[i].JobStatusId + '" />' + data[i].JobStatusName + '</td>' +
                                    '<td>' + SatusChange +
                                    ' &nbsp; <a href="/job/viewjob/' + data[i].JobId + '" id="aviewjob"><i class="fa fa-eye"></i> View</a></td>');

                        $('#tbodyJobsList').append(tr);
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
                $('#tbodyJobsList').append(tr);
            }

            hideloading();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
}

function ChangeStatus(obj,Action) {
    var JobId = $(obj).closest('tr').find('#hiddenjobid').val();

    if (Action == 1) {
        $('#ModelLabel').html("Publish Job");
        $('#pActionText').html("Are you sure do you want to Publish this job?");
        $('#ButAction').html("Publish");
    }
    else if (Action == 5) {
        $('#ModelLabel').html("Unpublish Job");
        $('#pActionText').html("Are you sure do you want to Unpublish this job?");
        $('#ButAction').html("Unpublish");
    } 
    $('#hfAction').val(Action);
    $('#hfJobId').val(JobId);
    $('#modalcompanyuser').modal();
}

function CompanyActions() {
    hideallalerts();
    var EncryptedJobId = $("#hfJobId").val();
    var Action = $("#hfAction").val();
    var ModifiedBy = $("#hiddenloginid").val();
    showloading();

    var input = [];
    input = {
        EncryptedJobId: EncryptedJobId,
        Action: Action,
        ModifiedBy: ModifiedBy
    };

    $.ajax({
        type: "POST",
        data: (input),
        url: "/SuperUser/user/ChangeJobAction",
        dataType: "json",
        success: function (data) {
            if (data.StatusId == 1) {
                showsuccessalert(data.StatusMessage);
                $("#hiddenselectedjobid").val('0');
                GetJobsList();
            }
            else {
                showwarningalert(data.StatusMessage);
            }
            $('#closemodalcompanyuser').click();

            hideloading();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });

}