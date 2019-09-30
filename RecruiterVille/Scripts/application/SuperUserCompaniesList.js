function getcompanieslist() {
    showloading();
    $('#tbodyCompaniesList tr').remove();

    $.ajax({
        type: "GET",
        url: "/SuperUser/user/getcompanieslist",
        dataType: "json",
        success: function (data) {
            var ishavingusers = true;

            if (data != null) {
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        var Actions = '';
                        if (data[i].ActiveStatusId == 0)//Hold
                        {
                            Actions = '<a href="javascript:void(0)" id="ActiveStatus" onclick="ChangeStatus(1,this)"><i class="fa fa-trash-o"></i> Active</a>&nbsp; ' +
                                '<a href="javascript:void(0)" id="ActiveStatus" onclick="ChangeStatus(2,this)"><i class="fa fa-trash-o"></i> Remove</a>&nbsp; ' +
                                '<a href="javascript:void(0)" id="ActiveStatus" onclick="ChangeStatus(3,this)"><i class="fa fa-trash-o"></i> Terminate</a>';
                        }
                        else if (data[i].ActiveStatusId == 1)//Active
                        {
                            Actions = '<a href="javascript:void(0)" id="ActiveStatus" onclick="ChangeStatus(0,this)"><i class="fa fa-trash-o"></i> Hold</a>&nbsp; ' +
                                '<a href="javascript:void(0)" id="ActiveStatus" onclick="ChangeStatus(2,this)"><i class="fa fa-trash-o"></i> Remove</a>&nbsp; ' +
                                '<a href="javascript:void(0)" id="ActiveStatus" onclick="ChangeStatus(3,this)"><i class="fa fa-trash-o"></i> Terminate</a>';
                        }
                        else if (data[i].ActiveStatusId == 2) {//Remove
                            Actions = '<a href="javascript:void(0)" id="ActiveStatus" onclick="ChangeStatus(1,this)"><i class="fa fa-trash-o"></i> Active</a>&nbsp; ' +
                                '<a href="javascript:void(0)" id="ActiveStatus" onclick="ChangeStatus(3,this)"><i class="fa fa-trash-o"></i> Terminate</a>';
                        }
                        else if (data[i].ActiveStatusId == 3) {//Terminate
                            Actions = '<a href="javascript:void(0)" id="ActiveStatus" onclick="ChangeStatus(1,this)"><i class="fa fa-trash-o"></i> Active</a>';
                        }
                        var tr = $('<tr />');

                        $(tr).append('<td>' + (i + 1) + '<input type="hidden" id="CompanyId" value="' + data[i].CompanyId + '" /></td>' +
                                    '<td>' + data[i].CompanyName + '</td>' +
                                    '<td>' + data[i].CreatedBy + ' (' + data[i].CreatedEmailId + ')<input type="hidden" id="hiddenCreatedById" value="' + data[i].CreatedById + '" /></td>' +
                                    '<td>' + data[i].UsersCount + '</td>' +
                                    '<td>' + data[i].PackageName + '<input type="hidden" id="hiddenPackageId" value="' + data[i].PackageId + '" /></td>' +
                                    '<td>' + data[i].ActiveStatus + '<input type="hidden" id="hfActiveStatusId" value="' + data[i].ActiveStatusId + '" /></td>' +
                                    '<td> ' + Actions + ' <a href="javascript:void(0)" id="adeleteuser" onclick="deleteuser(this)"><i class="fa fa-trash-o"></i> Renew</a> &nbsp; <a href="javascript:void(0)" id="adeleteuser" onclick="deleteuser(this)"><i class="fa fa-trash-o"></i> Upgrade</a> &nbsp; <a href="javascript:void(0)" id="adeleteuser" onclick="deleteuser(this)"><i class="fa fa-trash-o"></i> Degrade</a>' +
                                    ' &nbsp; <a href="javascript:void(0)" id="adeleteuser" onclick="deleteuser(this)"><i class="fa fa-trash-o"></i> Assign Emails</a></td>');

                        $('#tbodyCompaniesList').append(tr);
                    }
                }
                else {
                    ishavingusers = false;
                }
            }
            else {
                ishavingusers = false;
            }

            if (!ishavingusers) {
                var tr = '<tr />';
                $(tr).append('<td colspan="7">No companies found.</td>');
                $('#tbodyusers').append(tr);
            }

            hideloading();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
}

function ChangeStatus(Action, obj) {
    var CompanyId = $(obj).closest('tr').find('#CompanyId').val();

    if (Action == 0) {
        $('#ModelLabel').html("Hold Company");
        $('#pActionText').html("Are you sure do you want to Hold this company?");
        $('#ButAction').html("Hold");
    }
    else if (Action == 1) {
        $('#ModelLabel').html("Activate Company");
        $('#pActionText').html("Are you sure do you want to Activate this company?");
        $('#ButAction').html("Activate");
    }
    else if (Action == 2) {
        $('#ModelLabel').html("Remove Company");
        $('#pActionText').html("Are you sure do you want to Remove this company?");
        $('#ButAction').html("Remove");
    }
    else if (Action == 3) {
        $('#ModelLabel').html("Terminate Company");
        $('#pActionText').html("Are you sure do you want to Terminate this company?");
        $('#ButAction').html("Terminate");
    }
    $('#hfAction').val(Action);
    $('#hfCompanyId').val(CompanyId);
    $('#modalcompanyuser').modal();
}

function CompanyActions() {
    hideallalerts();
    var CompanyId = $("#hfCompanyId").val();
    var Action = $("#hfAction").val();
    var ModifiedBy = $("#hiddenloginid").val();
    showloading();

    var input = [];
    input = {
        CompanyId: CompanyId,
        Action: Action,
        ModifiedBy: ModifiedBy
    };

    $.ajax({
        type: "POST",       
        data: (input),
        url: "/SuperUser/user/ChangeAction",
        dataType: "json",
        success: function (data) {
            if (data.StatusId == 1) {
                showsuccessalert(data.StatusMessage);
                $("#hiddenselectedjobid").val('0'); 
                getcompanieslist();
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