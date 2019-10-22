function getprofileslist() {
    showloading();
    $('#tbodyProfilesList tr').remove();

    $.ajax({
        type: "GET",
        url: "/SuperUser/user/getprofileslist",
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

                        $(tr).append('<td>' + (i + 1) + '<input type="hidden" id="ProfileId" value="' + data[i].ProfileId + '" /></td>' +
                                    '<td>' + data[i].FirstName + ' ' + data[i].LastName + '</td>' +
                                    '<td>' + data[i].EmailId + '</td>' +
                                    '<td><a href="' + data[i].ResumePath + '" download>Download Resume</a></td>' + 
                                    '<td>' + data[i].MobileNumber + '</td>' +
                                    '<td>' + data[i].QualificationName + '</td>' +
                                    '<td>' + data[i].Experience + '</td>' +
                                    '<td>' + data[i].Industry + '</td>' +
                                    '<td>' + data[i].Location + '</td>' +
                                    '<td>' + data[i].DOB + '</td>' +
                                    '<td>' + data[i].CreatedBy + '<input type="hidden" id="hiddenCreatedById" value="' + data[i].CreatedById + '" /></td>' +
                                     '<td>' + data[i].ActiveStatus + '<input type="hidden" id="hfActiveStatusId" value="' + data[i].ActiveStatusId + '" /></td>' +
                                    '<td> ' + Actions + ' <a href="javascript:void(0)" id="adeleteuser" onclick="deleteuser(this)"><i class="fa fa-trash-o"></i> Renew</a> &nbsp; <a href="javascript:void(0)" id="adeleteuser" onclick="deleteuser(this)"><i class="fa fa-trash-o"></i> Upgrade</a> &nbsp; <a href="javascript:void(0)" id="adeleteuser" onclick="deleteuser(this)"><i class="fa fa-trash-o"></i> Degrade</a>' +
                                    ' &nbsp; <a href="javascript:void(0)" id="adeleteuser" onclick="deleteuser(this)"><i class="fa fa-trash-o"></i> Assign Emails</a>&nbsp;<a href="/SuperUser/user/profileview/' + data[i].EnProfileId + '" id="aviewprofile"><i class="fa fa-eye"></i> View</a></td>');

                        $('#tbodyProfilesList').append(tr);
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