function validatepassword(obj) {
    if (validatetextbox(obj) == false) {
        return false;
    }
    else if (checkpasswordcriteria(obj) == false) {
        return false;
    }
}

function validateconfirmpassword(obj) {
    var textpassword = $("#textpassword");
    var isvalid = true;

    $(textpassword).closest('.form-group').removeClass("has-success");
    $(textpassword).closest('.form-group').removeClass("has-error");
    $(obj).closest('.form-group').removeClass("has-success");
    $(obj).closest('.form-group').removeClass("has-error");

    if (validatepassword(textpassword) == false) {
        isvalid = false;
    }
    if (validatepassword(obj) == false) {
        isvalid = false;
    }
    if ($(textpassword).val().trim() != $(obj).val().trim()) {
        $(textpassword).closest('.form-group').addClass("has-error");
        $(obj).closest('.form-group').addClass("has-error");
        isvalid = false;
    }
    else {
        $(textpassword).closest('.form-group').addClass("has-success");
        $(obj).closest('.form-group').addClass("has-success");
        isvalid = true;
    }
    return isvalid;
}

var registrationid = 0;
var username = '';
var password = '';

function Register() {
    hideallalerts();
    var textfullname = $("#textfullname");
    var textcompanyname = $("#textcompanyname");
    var textemailid = $("#textemailid");
    var textcontactnumber = $("#textcontactnumber");
    var textpassword = $("#textpassword");
    var textconfirmpassword = $("#textconfirmpassword");
    var textaboutme = $("#textaboutme");
    var checktermsconditions = $("#checktermsconditions");

    var isvalid = true;

    if (validatetextbox(textfullname) == false) {
        isvalid = false;
    }
    if (validatetextbox(textcompanyname) == false) {
        isvalid = false;
    }
    if (validateemailid(textemailid) == false) {
        isvalid = false;
    }
    if (validatephonenumber(textcontactnumber) == false) {
        isvalid = false;
    }
    if (validatepassword(textpassword) == false) {
        isvalid = false;
    }
    if (validateconfirmpassword(textconfirmpassword) == false) {
        isvalid = false;
    }
    if ($(checktermsconditions)[0].checked == false) {
        $($('#checktermsconditions').closest('label')[0]).css("color", "#f9243f");
        isvalid = false;
    }
    else {
        $($('#checktermsconditions').closest('label')[0]).css("color", "");
    }

    if (isvalid) {
        showloading();

        var packagename = $('#hiddenpackagename').val();
        var packageid = 0;

        if (packagename.toLowerCase() == "entreprise") {
            packageid = 4;
        }
        else if (packagename.toLowerCase() == "premium") {
            packageid = 3;
        }
        else if (packagename.toLowerCase() == "platinum") {
            packageid = 2;
        }
        else {
            packageid = 1;
        }
        
        var input = [];
        input = {
            fullname: textfullname.val().trim(),
            companyname: textcompanyname.val().trim(),
            emailid: textemailid.val().trim(),
            contactnumber: textcontactnumber.val().trim(),
            password: textpassword.val().trim(),
            aboutme: textaboutme.val().trim(),
            packageid: packageid
        };
        
        $.ajax({
            type: "POST",
            data: (input),
            url: "/account/userregistration",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showinfoalert(data.StatusMessage);
                    registrationid = data.RegistrationId;
                    username = textemailid.val().trim();
                    password = textpassword.val().trim();
                    $('#divverification').css("display", "block");
                    $('#divregistration').remove();
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

function validateverificationcode(obj) {
    $(obj).closest('.form-group').removeClass("has-success");
    $(obj).closest('.form-group').removeClass("has-error");

    if (validatetextbox(obj) == false) {
        return false;
    }
    else if ($(obj).val().trim().length != 6) {
        $(obj).closest('.form-group').addClass("has-error");
        return false;
    }
    else {
        $(obj).closest('.form-group').addClass("has-success");
        return true;
    }
}

function VerifyAccount() {
    hideallalerts();
    var textverificationcode = $("#textverificationcode");

    var isvalid = true;

    if (validateverificationcode(textverificationcode) == false) {
        isvalid = false;
    }

    if (isvalid) {
        showloading();

        var input = [];
        input = {
            registrationid: registrationid,
            verificationcode: textverificationcode.val().trim()
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/account/verifyuserregistration",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    UserLogin();
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

function UserLogin() {
    hideallalerts();

    if (username != '' && password != '') {
        showloading();

        var logindetails = [];
        logindetails = {
            username: username,
            password: password,
            isremember: false,
            isfromlogin: false
        };

        $.ajax({
            type: "POST",
            data: (logindetails),
            url: "/account/userlogin",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    window.location = "/user/dashboard";
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