var weburl = "http://localhost:50963/";

function closemessage(obj) {
    $(obj).closest('.alert').hide();
}

function showsuccessalert(message) {
    $('#divalertinfo').hide();
    $('#divalertwarning').hide();
    $('#divalertdanger').hide();

    $('#divalertsuccess').show();
    $('#spanalertsuccess').html(message);
}

function showwarningalert(message) {
    $('#divalertinfo').hide();
    $('#divalertsuccess').hide();
    $('#divalertdanger').hide();

    $('#divalertwarning').show();
    $('#spanalertwarning').html(message);
}

function showerroralert(message) {
    $('#divalertinfo').hide();
    $('#divalertsuccess').hide();
    $('#divalertwarning').hide();

    $('#divalertdanger').show();
    $('#spanalertdanger').html(message);
}

function showinfoalert(message) {
    $('#divalertdanger').hide();
    $('#divalertsuccess').hide();
    $('#divalertwarning').hide();

    $('#divalertinfo').show();
    $('#spanalertinfo').html(message);
}

function hideallalerts() {
    $('#divalertdanger').hide();
    $('#divalertsuccess').hide();
    $('#divalertwarning').hide();
    $('#divalertinfo').hide();
}

function showloading() {
    $('#divloading').show();
}

function hideloading() {
    $('#divloading').hide();
}

function validatetextbox(obj) {
    $(obj).closest('.form-group').removeClass("has-success");
    $(obj).closest('.form-group').removeClass("has-error");
    if ($(obj).val().trim() == "") {
        $(obj).closest('.form-group').addClass("has-error");
        return false;
    }
    else {
        $(obj).closest('.form-group').addClass("has-success");
        return true;
    }
}

function validateemailid(obj) {
    $(obj).closest('.form-group').removeClass("has-success");
    $(obj).closest('.form-group').removeClass("has-error");
    var re = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;

    if ($(obj).val().trim() == "") {
        $(obj).closest('.form-group').addClass("has-error");
        return false;
    }
    else if (!re.test($.trim($(obj).val()))) {
        $(obj).closest('.form-group').addClass("has-error");
        return false;
    }
    else {
        $(obj).closest('.form-group').addClass("has-success");
        return true;
    }
}

function validatephonenumber(obj) {
    $(obj).closest('.form-group').removeClass("has-success");
    $(obj).closest('.form-group').removeClass("has-error");
    var phonewithspecialchars = /^\(?([0-9]{3})\)?[-()]?([0-9]{3})[-()]?([0-9]{4})$/;
    var phoneno = /^\d{10}$/;
    var inputtext = $(obj).val().trim();

    if (inputtext.match(phonewithspecialchars)) {
        $(obj).closest('.form-group').addClass("has-success");
        return true;
    }
    else if (inputtext.match(phoneno)) {
        $(obj).closest('.form-group').addClass("has-success");
        return true;
    }
    else {
        $(obj).closest('.form-group').addClass("has-error");
        return false;
    }
}

function checkpasswordcriteria(obj) {
    $(obj).closest('.form-group').removeClass("has-success");
    $(obj).closest('.form-group').removeClass("has-error");

    var islengthmatched = false;
    var istherecapital = false;
    var istherenumber = false;
    var istherespecialcharacter = false;

    var pswd = $(obj).val().trim();

    //validate the length
    if (pswd.length >= 8) {
        islengthmatched = true;
    }

    //validate capital letter
    if (pswd.match(/[A-Z]/)) {
        istherecapital = true;
    }

    //validate number
    if (pswd.match(/\d/)) {
        istherenumber = true;
    }

    //validate special character
    var count = 0;
    var specialChars = "<>@!#$%^&*()_+[]{}?:;|'\"\\,./~`-=";
    for (i = 0; i < specialChars.length; i++) {
        if (pswd.indexOf(specialChars[i]) > -1) {
            count++;
            break;
        }
    }
    if (count > 0) {
        istherespecialcharacter = true;
    }

    if (islengthmatched && istherecapital && istherenumber && istherespecialcharacter) {
        $(obj).closest('.form-group').addClass("has-success");
        return true;
    }
    else {
        $(obj).closest('.form-group').addClass("has-error");
        return false;
    }
}
