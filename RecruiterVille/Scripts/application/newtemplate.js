function changeapplicationmethod(obj) {
    var applicationmethod = $(obj).val();

    if (applicationmethod == 1) {
        $('.emailmethod').css("display", "block");
        $('.urlmethod').css("display", "none");
    }
    else if (applicationmethod == 2) {
        $('.emailmethod').css("display", "none");
        $('.urlmethod').css("display", "block");
    }
    else {
        $('.emailmethod').css("display", "none");
        $('.urlmethod').css("display", "none");
    }
}

function validateminpayrate() {
    var textminpayrate = $("#textminpayrate");
    var textmaxpayrate = $("#textmaxpayrate");
    var isvalid = true;

    if (validatetextbox(textminpayrate) == false) {
        isvalid = false;
    }
    else {
        if (textmaxpayrate.val() != "") {
            var minrate = parseInt(textminpayrate.val());
            var maxrate = parseInt(textmaxpayrate.val());

            if (minrate > maxrate) {
                isvalid = false;
                $(textminpayrate).closest('.form-group').addClass("has-error");
                $(textmaxpayrate).closest('.form-group').addClass("has-error");
            }
        }
    }
}

function validatemaxpayrate() {
    var textminpayrate = $("#textminpayrate");
    var textmaxpayrate = $("#textmaxpayrate");
    var isvalid = true;

    if (validatetextbox(textmaxpayrate) == false) {
        isvalid = false;
    }
    else {
        if (textminpayrate.val() != "") {
            var minrate = parseInt(textminpayrate.val());
            var maxrate = parseInt(textmaxpayrate.val());

            if (minrate > maxrate) {
                isvalid = false;
                $(textminpayrate).closest('.form-group').addClass("has-error");
                $(textmaxpayrate).closest('.form-group').addClass("has-error");
            }
        }
    }
}

function validateminexp() {
    var textminexp = $("#textminexp");
    var textmaxexp = $("#textmaxexp");
    var isvalid = true;

    if (validatetextbox(textminexp) == false) {
        isvalid = false;
    }
    else {
        if (textmaxexp.val() != "") {
            var minexp = parseInt(textminexp.val());
            var maxexp = parseInt(textmaxexp.val());

            if (minexp > maxexp) {
                isvalid = false;
                $(textminexp).closest('.form-group').addClass("has-error");
                $(textmaxexp).closest('.form-group').addClass("has-error");
            }
        }
    }
}

function validatemaxexp() {
    var textminexp = $("#textminexp");
    var textmaxexp = $("#textmaxexp");
    var isvalid = true;

    if (validatetextbox(textmaxexp) == false) {
        isvalid = false;
    }
    else {
        if (textminexp.val() != "") {
            var minexp = parseInt(textminexp.val());
            var maxexp = parseInt(textmaxexp.val());

            if (minexp > maxexp) {
                isvalid = false;
                $(textminexp).closest('.form-group').addClass("has-error");
                $(textmaxexp).closest('.form-group').addClass("has-error");
            }
        }
    }
}

function savejobtemplatedetails() {
    hideallalerts();
    var isvalid = true;
    var loginid = $("#hiddenloginid").val();
    var companyid = $("#hiddencompanyid").val();

    var texttemplatename = $("#texttemplatename");
    var textjobtitle = $("#textjobtitle");
    var textjoblocation = $("#textjoblocation");
    var selectpaycurrency = $("#selectpaycurrency");
    var textminpayrate = $("#textminpayrate");
    var textmaxpayrate = $("#textmaxpayrate");
    var selectpaytype = $("#selectpaytype");
    var selectjobtype = $("#selectjobtype");
    var textduartion = $("#textduartion");
    var textminexp = $("#textminexp");
    var textmaxexp = $("#textmaxexp");
    var selectduration = $("#selectduration");
    var selecttravelrequirements = $("#selecttravelrequirements");
    var selectindustry = $("#selectindustry");
    var selectsubindustries = $("#selectsubindustries");
    var selectskills = $("#selectskills");
    var selectapplicationmethod = $("#selectapplicationmethod");
    var texttoemail = $("#texttoemail");
    var textccemail = $("#textccemail");
    var texturl = $("#texturl");
    var checkworkfromhome = $("#checkworkfromhome");
    var textjobdescription = $("#textjobdescription");

    var jobtype = getmultiselectedvalues(selectjobtype);
    var subindustries = getmultiselectedvalues(selectsubindustries);
    //var skills = getmultiselectedvalues(selectskills);

    if (validatetextbox(texttemplatename) == false) {
        isvalid = false;
    }
    if (validatetextbox(textjobtitle) == false) {
        isvalid = false;
    }
    if (validatedropdown(selectpaycurrency) == false) {
        isvalid = false;
    }
    if (validateminpayrate(textminpayrate) == false) {
        isvalid = false;
    }
    if (validatemaxpayrate(textmaxpayrate) == false) {
        isvalid = false;
    }
    if (validatedropdown(selectpaytype) == false) {
        isvalid = false;
    }
    if (jobtype == "") {
        $(selectjobtype).closest('.form-group').addClass("has-error");
        $(selectjobtype).closest('.form-group').removeClass("has-success");
        isvalid = false;
    }
    else {
        $(selectjobtype).closest('.form-group').removeClass("has-error");
        $(selectjobtype).closest('.form-group').addClass("has-success");
    }
    if (validatetextbox(textduartion) == false) {
        isvalid = false;
    }
    if (validateminexp(textminexp) == false) {
        isvalid = false;
    }
    if (validatemaxexp(textmaxexp) == false) {
        isvalid = false;
    }
    if (validatedropdown(selectduration) == false) {
        isvalid = false;
    }
    if (validatedropdown(selecttravelrequirements) == false) {
        isvalid = false;
    }
    if (validatedropdown(selectindustry) == false) {
        isvalid = false;
    }
    if (subindustries == "") {
        $(selectsubindustries).closest('.form-group').addClass("has-error");
        $(selectsubindustries).closest('.form-group').removeClass("has-success");
        isvalid = false;
    }
    else {
        $(selectsubindustries).closest('.form-group').removeClass("has-error");
        $(selectsubindustries).closest('.form-group').addClass("has-success");
    }
    //if (skills == "") {
    //    $(selectskills).closest('.form-group').addClass("has-error");
    //    $(selectskills).closest('.form-group').removeClass("has-success");
    //    isvalid = false;
    //}
    //else {
    //    $(selectskills).closest('.form-group').removeClass("has-error");
    //    $(selectskills).closest('.form-group').addClass("has-success");
    //}
    if (selectapplicationmethod.val() != 0) {
        if (selectapplicationmethod.val() == 1) {
            if (validateemailid(texttoemail) == false) {
                isvalid = false;
            }
            if (validateemailid(textccemail) == false) {
                isvalid = false;
            }
        }
        else {
            if (validatetextbox(texturl) == false) {
                isvalid = false;
            }
        }
    }
    if (validatetextbox(textjobdescription) == false) {
        isvalid = false;
    }
    if (validatetextbox(selectskills) == false) {
        isvalid = false;
    }

    if (isvalid) {
        showloading();

        var input = [];
        input = {
            strJobTemplateId: "",
            JobTitle: textjobtitle.val().trim(),
            JobLocation: textjoblocation.val().trim(),
            TemplateName: texttemplatename.val().trim(),
            PayType: selectpaytype.val(),
            PayCurrency: selectpaycurrency.val(),
            MinPayRate: textminpayrate.val().trim(),
            MaxPayRate: textmaxpayrate.val().trim(),
            JobDurationType: selectduration.val(),
            JobDuration: textduartion.val().trim(),
            MinExp: textminexp.val().trim(),
            MaxExp: textmaxexp.val().trim(),
            TravelAllowanceType: selecttravelrequirements.val(),
            TravelAllowances: 0,
            IsWFHAvailable: checkworkfromhome[0].checked,
            JobDescription: textjobdescription.val().trim(),
            IndustryId: selectindustry.val(),
            ApplicationMethodType: selectapplicationmethod.val(),
            ApplicationToEmailId: texttoemail.val().trim(),
            ApplicationCcEmailId: textccemail.val().trim(),
            ApplicationURL: texturl.val().trim(),
            SkillIds: selectskills.val().trim(),
            SubIndustryIds: subindustries,
            JobTypeIds: jobtype
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/job/insertandupdatejobtempatedetails",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showsuccessalert(data.StatusMessage);
                    $('#ajobtemplateslist')[0].click();
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