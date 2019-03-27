function getuserslist() {
    showloading();
    $('#tbodyusers tr').remove();

    $.ajax({
        type: "GET",
        url: "/recruiter/getuserslist",
        dataType: "json",
        success: function (data) {
            var ishavingusers = true;

            if (data != null) {
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        var tr = $('<tr />');
                        var address = (data[i].Street == "") ? "" : data[i].Street;
                        address = (address == "") ? data[i].City : address + ((data[i].City == "") ? "" : ", " + data[i].City);
                        address = (address == "") ? data[i].State : address + ((data[i].State == "") ? "" : ", " + data[i].State);
                        address = (address == "") ? data[i].State : address + ((data[i].State == "") ? "" : ", " + data[i].State);
                        address = (address == "") ? data[i].Country : address + ((data[i].Country == "") ? "" : ", " + data[i].Country);
                        address = (address == "") ? data[i].Zipcode : address + ((data[i].Zipcode == "") ? "" : " - " + data[i].Zipcode);

                        $(tr).append('<td>' + (i + 1) + '<input type="hidden" id="hiddenuserid" value="' + data[i].UserId + '" /></td>' +
                                    '<td>' + data[i].FullName + '</td>' +
                                    '<td>' + data[i].EmailId + '</td>' +
                                    '<td>' + data[i].ContactNumber + '</td>' +
                                    '<td>' + data[i].RoleName + '</td>' +
                                    '<td>' + data[i].Designation + '</td>' +
                                    '<td>' + address + '</td>' +
                                    '<td><a href="javascript:void(0)" id="aedituser" onclick="edituser(this)"> <i class="fa fa-pencil"></i> Edit</a> &nbsp; <a href="javascript:void(0)" id="adeleteuser" onclick="deleteuser(this)"><i class="fa fa-trash-o"></i> Delete</a></td>');

                        $('#tbodyusers').append(tr);
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
                $(tr).append('<td colspan="8">No users found in your company.</td>');
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

function addnewuser() {
    clearfields();
    $("#hiddenselecteduserid").val('0');
    $('#textuseremailid').removeAttr('disabled');
    $('#modalusercreation').modal();
}

function clearfields() {
    $('#textuserfullname').val('');
    $('#textuseremailid').val('');
    $('#textusercontact').val('');
    $('#fileprofilepicture').val('');
    $('#hiddenprofilepic').val('');
    $('#selectuserrole').val('0');
    $('#textuserstreet').val('');
    $('#textusercity').val('');
    $('#textuserstate').val('');
    $('#textusercountry').val('');
    $('#textuserzipcode').val('');
    $('#textuserlandmark').val('');
    $('#textaboutme').val('');

    $('.has-error').removeClass("has-error");
    $('.has-success').removeClass("has-success");
}

function edituser(obj) {
    clearfields();
    showloading();
    var userid = $(obj).closest('tr').find('#hiddenuserid').val();

    if (userid != "" || userid != "0") {
        $.ajax({
            type: "GET",
            url: "/recruiter/getuserdetailsbyid/" + parseInt(userid),
            dataType: "json",
            success: function (data) {
                if (data != null) {
                    $("#hiddenselecteduserid").val(userid);
                    $('#textuseremailid').attr('disabled', 'disabled');

                    $('#textuserfullname').val(data.FullName);
                    $('#textuseremailid').val(data.EmailId);
                    $('#textusercontact').val(data.ContactNumber);
                    $('#hiddenprofilepic').val(data.ProfilePicPath);
                    $('#textuserstreet').val(data.Street);
                    $('#selectuserrole').val(data.RoleId);
                    $('#textusercity').val(data.City);
                    $('#textuserstate').val(data.State);
                    $('#textusercountry').val(data.Country);
                    $('#textuserzipcode').val(data.Zipcode);
                    $('#textuserlandmark').val(data.Landmark);
                    $('#textaboutme').val(data.AboutMe);

                    $('#modalusercreation').modal();
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

function uploaduserprofilepic() {
    var fileprofilepicture = $('#fileprofilepicture');

    if (validateimage(fileprofilepicture) == false) {
        return false;
    }
    else {
        var formdata = new FormData();
        var file = document.getElementById('fileprofilepicture').files[0]
        if (formdata) {
            formdata.append("file", file);
            $.ajax({
                url: "/recruiter/uploaduserprofilepic",
                type: "POST",
                data: formdata,
                processData: false,
                contentType: false,
                success: function (data) {
                    $('#hiddenprofilepic').val(data.imagepath);
                }
            });
        }
    }
}

function saveuserdetails() {
    hideallalerts();
    var userid = $("#hiddenselecteduserid").val();
    var textuserfullname = $("#textuserfullname");
    var textuseremailid = $("#textuseremailid");
    var textusercontact = $("#textusercontact");
    var fileprofilepicture = $("#fileprofilepicture");
    var hiddenprofilepic = $("#hiddenprofilepic");
    var selectuserrole = $("#selectuserrole");
    var textuserstreet = $("#textuserstreet");
    var textusercity = $("#textusercity");
    var textuserstate = $("#textuserstate");
    var textusercountry = $("#textusercountry");
    var textuserzipcode = $("#textuserzipcode");
    var textuserlandmark = $("#textuserlandmark");
    var textaboutme = $("#textaboutme");

    var isvalid = true;

    if (validatetextbox(textuserfullname) == false) {
        isvalid = false;
    }
    if (validateemailid(textuseremailid) == false) {
        isvalid = false;
    }
    if (validatephonenumber(textusercontact) == false) {
        isvalid = false;
    }
    if (validatedropdown(selectuserrole) == false) {
        isvalid = false;
    }
    if (validatetextbox(textaboutme) == false) {
        isvalid = false;
    }
    if (validatetextbox(hiddenprofilepic) == false) {
        isvalid = false;
    }

    if (isvalid) {
        showloading();

        var input = [];
        input = {
            UserId: (userid == "") ? 0 : userid,
            FullName: textuserfullname.val().trim(),
            EmailId: textuseremailid.val().trim(),
            ContactNumber: textusercontact.val().trim(),
            AboutMe: textaboutme.val().trim(),
            ProfilePicPath: hiddenprofilepic.val().trim(),
            RoleId: selectuserrole.val(),
            Street: textuserstreet.val().trim(),
            Landmark: textuserlandmark.val().trim(),
            City: textusercity.val().trim(),
            State: textuserstate.val().trim(),
            Country: textusercountry.val().trim(),
            Zipcode: textuserzipcode.val().trim()
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/recruiter/insertandupdateuserdetails",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showsuccessalert(data.StatusMessage);
                    $("#hiddenselecteduserid").val('0');
                    $('#closemodalusercreation').click();
                    getuserslist();
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
    else {
        return false;
    }
}

function deleteuser(obj) {
    var userid = $(obj).closest('tr').find('#hiddenuserid').val();
    $("#hiddenselecteduserid").val(userid);
    $('#modaldeleteuser').modal();
}

function deleteuserconfirm() {
    hideallalerts();
    var userid = $("#hiddenselecteduserid").val();

    if (userid != "" || userid != "0") {
        $.ajax({
            type: "GET",
            url: "/recruiter/deleteuserdetails/" + parseInt(userid),
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showsuccessalert(data.StatusMessage);
                    $("#hiddenselecteduserid").val('0');
                    $('#closemodaldeleteuser').click();
                    getuserslist();
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