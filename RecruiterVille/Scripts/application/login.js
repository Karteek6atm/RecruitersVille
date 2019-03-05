function UserLogin() {
    hideallalerts();
    var textemailid = $("#textemailid");
    var textpassword = $("#textpassword");
    var checkremember = $("#checkremember");

    var isvalid = true;

    if (validateemailid(textemailid) == false) {
        isvalid = false;
    }
    if (validatetextbox(textpassword) == false) {
        isvalid = false;
    }

    if (isvalid) {
        showloading();

        var logindetails = [];
        logindetails = {
            username: textemailid.val().trim(),
            password: textpassword.val().trim(),
            isremember: checkremember.checked,
            isfromlogin: true
        };

        $.ajax({
            type: "POST",
            data: (logindetails),
            url: "/account/userlogin",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    if (data.IsFirstLogin) {
                        window.location = "/user/profile";
                    }
                    else {
                        window.location = "/user/dashboard";
                    }
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

function OpenForgotPassword() {
    $('#divlogin').css("display", "none");
    $('#divforgotpwd').css("display", "block");
    $("#textforgotemailid").val('');
    $("#textforgotemailid").closest('.form-group').removeClass("has-success");
    $("#textforgotemailid").closest('.form-group').removeClass("has-error");
}

function OpenLogin() {
    $('#divforgotpwd').css("display", "none");
    $('#divlogin').css("display", "block");
}

function validatepassword(obj) {
    if (validatetextbox(obj) == false) {
        return false;
    }
    else if (checkpasswordcriteria(obj) == false) {
        return false;
    }
}

function validateconfirmpassword(obj) {
    var textpassword = $("#textforgotnewpassword");
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

var requestid = 0;

function ForgotPassword() {
    hideallalerts();
    var textforgotemailid = $("#textforgotemailid");

    var isvalid = true;

    if (validateemailid(textforgotemailid) == false) {
        isvalid = false;
    }

    if (isvalid) {
        showloading();

        var input = [];
        input = {
            emailid: textforgotemailid.val().trim()
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/account/userforgotpasswordrequest",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showinfoalert(data.StatusMessage);
                    requestid = data.RequestId;
                    $('#divforgotpwd').css("display", "none");
                    $('#divresetpassword').css("display", "block");
                    $("#verificationcode").val('');
                    $("#textforgotnewpassword").val('');
                    $("#textforgotconfirmpassword").val('');
                    $("#verificationcode").closest('.form-group').removeClass("has-success");
                    $("#verificationcode").closest('.form-group').removeClass("has-error");
                    $("#textforgotnewpassword").closest('.form-group').removeClass("has-success");
                    $("#textforgotnewpassword").closest('.form-group').removeClass("has-error");
                    $("#textforgotconfirmpassword").closest('.form-group').removeClass("has-success");
                    $("#textforgotconfirmpassword").closest('.form-group').removeClass("has-error");
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

function UpdateForgotPassword() {
    hideallalerts();
    var textverificationcode = $("#textverificationcode");
    var textpassword = $("#textforgotnewpassword");
    var textconfirmpassword = $("#textforgotconfirmpassword");

    var isvalid = true;

    if (validateverificationcode(textverificationcode) == false) {
        isvalid = false;
    }
    if (validatepassword(textpassword) == false) {
        isvalid = false;
    }
    if (validateconfirmpassword(textconfirmpassword) == false) {
        isvalid = false;
    }

    if (isvalid) {
        showloading();

        var input = [];
        input = {
            requestid: requestid,
            password: textpassword.val().trim(),
            verificationcode: textverificationcode.val().trim()
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/account/updateforgotpassword",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    $('#divresetpassword').css("display", "none");
                    $('#divlogin').css("display", "block");
                    showsuccessalert(data.StatusMessage);
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