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

    //if (validatetextbox(textminpayrate) == false) {
    //    isvalid = false;
    //}
    //else {
        if (textmaxpayrate.val() != "") {
            var minrate = parseInt(textminpayrate.val());
            var maxrate = parseInt(textmaxpayrate.val());

            if (minrate > maxrate) {
                isvalid = false;
                $(textminpayrate).closest('.form-group').addClass("has-error");
                $(textmaxpayrate).closest('.form-group').addClass("has-error");
            }
        }
    //}
}

function validatemaxpayrate() {
    var textminpayrate = $("#textminpayrate");
    var textmaxpayrate = $("#textmaxpayrate");
    var isvalid = true;

    //if (validatetextbox(textmaxpayrate) == false) {
    //    isvalid = false;
    //}
    //else {
        if (textminpayrate.val() != "") {
            var minrate = parseInt(textminpayrate.val());
            var maxrate = parseInt(textmaxpayrate.val());

            if (minrate > maxrate) {
                isvalid = false;
                $(textminpayrate).closest('.form-group').addClass("has-error");
                $(textmaxpayrate).closest('.form-group').addClass("has-error");
            }
        }
    //}
}

function validateminexp() {
    var textminexp = $("#textminexp");
    var textmaxexp = $("#textmaxexp");
    var isvalid = true;

    //if (validatetextbox(textminexp) == false) {
    //    isvalid = false;
    //}
    //else {
        if (textmaxexp.val() != "") {
            var minexp = parseInt(textminexp.val());
            var maxexp = parseInt(textmaxexp.val());

            if (minexp > maxexp) {
                isvalid = false;
                $(textminexp).closest('.form-group').addClass("has-error");
                $(textmaxexp).closest('.form-group').addClass("has-error");
            }
        }
    //}
}

function validatemaxexp() {
    var textminexp = $("#textminexp");
    var textmaxexp = $("#textmaxexp");
    var isvalid = true;

    //if (validatetextbox(textmaxexp) == false) {
    //    isvalid = false;
    //}
    //else {
        if (textminexp.val() != "") {
            var minexp = parseInt(textminexp.val());
            var maxexp = parseInt(textmaxexp.val());

            if (minexp > maxexp) {
                isvalid = false;
                $(textminexp).closest('.form-group').addClass("has-error");
                $(textmaxexp).closest('.form-group').addClass("has-error");
            }
        }
    //}
}

function validatepostfromdate() {
    var textpostfromdate = $("#textpostfromdate");
    var textposttodate = $("#textposttodate");
    var isvalid = true;
    var fromdate = textpostfromdate.val();
    var todate = textposttodate.val();

    if (fromdate != "") {
        if (validatedate(textpostfromdate) == false) {
            isvalid = false;
        }
        else {
            if (todate != "") {
                if (validatedate(textposttodate) == false) {
                    isvalid = false;
                }
                else if (new Date(fromdate) > new Date(todate)) {
                    isvalid = false;
                    $(textpostfromdate).closest('.form-group').addClass("has-error");
                    $(textposttodate).closest('.form-group').addClass("has-error");
                }
            }
        }
    }

    return isvalid;
}

function validateposttodate() {
    var textpostfromdate = $("#textpostfromdate");
    var textposttodate = $("#textposttodate");
    var isvalid = true;
    var fromdate = textpostfromdate.val();
    var todate = textposttodate.val();

    if (todate != "") {
        if (validatedate(textposttodate) == false) {
            isvalid = false;
        }
        else {
            if (fromdate != "") {
                if (validatedate(textpostfromdate) == false) {
                    isvalid = false;
                }
                else if (new Date(fromdate) > new Date(todate)) {
                    isvalid = false;
                    $(textpostfromdate).closest('.form-group').addClass("has-error");
                    $(textposttodate).closest('.form-group').addClass("has-error");
                }
            }
        }
    }

    return isvalid;
}

function savejobdetails(jobstatus) {
    hideallalerts();
    var isvalid = true;
    var loginid = $("#hiddenloginid").val();
    var companyid = $("#hiddencompanyid").val();

    var textjobtitle = $("#textjobtitle");
    var textcompanyjobid = $("#textcompanyjobid");
    var checkastemplate = $("#checkastemplate");
    var texttemplatename = $("#texttemplatename");
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
    var textpostfromdate = $("#textpostfromdate");
    var textposttodate = $("#textposttodate");
    var selectapplicationmethod = $("#selectapplicationmethod");
    var texttoemail = $("#texttoemail");
    var textccemail = $("#textccemail");
    var texturl = $("#texturl");
    var checkworkfromhome = $("#checkworkfromhome");
    var textjobdescription = $("#textjobdescription");

    var jobtype = getmultiselectedvalues(selectjobtype);
    var subindustries = getmultiselectedvalues(selectsubindustries);
    //var skills = getmultiselectedvalues(selectskills);

    if (validatetextbox(textjobtitle) == false) {
        isvalid = false;
    }
    if (checkastemplate[0].checked) {
        if (validatetextbox(texttemplatename) == false) {
            isvalid = false;
        }
    }
    //if (validatetextbox(textjoblocation) == false) {
    //    isvalid = false;
    //}
    //if (validatedropdown(selectpaycurrency) == false) {
    //    isvalid = false;
    //}
    if (validateminpayrate(textminpayrate) == false) {
        isvalid = false;
    }
    if (validatemaxpayrate(textmaxpayrate) == false) {
        isvalid = false;
    }
    //if (validatedropdown(selectpaytype) == false) {
    //    isvalid = false;
    //}
    //if (jobtype == "") {
    //    $(selectjobtype).closest('.form-group').addClass("has-error");
    //    $(selectjobtype).closest('.form-group').removeClass("has-success");
    //    isvalid = false;
    //}
    //else {
    //    $(selectjobtype).closest('.form-group').removeClass("has-error");
    //    $(selectjobtype).closest('.form-group').addClass("has-success");
    //}
    //if (validatetextbox(textduartion) == false) {
    //    isvalid = false;
    //}
    if (validateminexp(textminexp) == false) {
        isvalid = false;
    }
    if (validatemaxexp(textmaxexp) == false) {
        isvalid = false;
    }
    //if (validatedropdown(selectduration) == false) {
    //    isvalid = false;
    //}
    //if (validatedropdown(selecttravelrequirements) == false) {
    //    isvalid = false;
    //}
    //if (validatedropdown(selectindustry) == false) {
    //    isvalid = false;
    //}
    //if (subindustries == "") {
    //    $(selectsubindustries).closest('.form-group').addClass("has-error");
    //    $(selectsubindustries).closest('.form-group').removeClass("has-success");
    //    isvalid = false;
    //}
    //else {
    //    $(selectsubindustries).closest('.form-group').removeClass("has-error");
    //    $(selectsubindustries).closest('.form-group').addClass("has-success");
    //}
    //if (skills == "") {
    //    $(selectskills).closest('.form-group').addClass("has-error");
    //    $(selectskills).closest('.form-group').removeClass("has-success");
    //    isvalid = false;
    //}
    //else {
    //    $(selectskills).closest('.form-group').removeClass("has-error");
    //    $(selectskills).closest('.form-group').addClass("has-success");
    //}
    if (validatepostfromdate(textpostfromdate) == false) {
        isvalid = false;
    }
    if (validateposttodate(textposttodate) == false) {
        isvalid = false;
    }
    //if (validatedropdown(selectapplicationmethod) == false) {
    //    isvalid = false;
    //}
    //else {
    //    var applicationmethod = selectapplicationmethod.val();

    //    if (applicationmethod == 1) {
    //        if (validateemailid(texttoemail) == false) {
    //            isvalid = false;
    //        }
    //        if (validateemailid(textccemail) == false) {
    //            isvalid = false;
    //        }
    //    }
    //    else {
    //        if (validatetextbox(texturl) == false) {
    //            isvalid = false;
    //        }
    //    }
    //}
    if (validatetextbox(textjobdescription) == false) {
        isvalid = false;
    }
    //if (validatetextbox(selectskills) == false) {
    //    isvalid = false;
    //}
     
    if (isvalid) {
        showloading();

        var input = [];
        input = {
            JobId: 0,
            CompanyJobId: textcompanyjobid.val().trim(),
            JobTitle: textjobtitle.val().trim(),
            JobLocation: textjoblocation.val().trim(),
            IsJobTemplate: checkastemplate[0].checked,
            TemplateName: (checkastemplate[0].checked ? texttemplatename.val().trim() : ""),
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
            PostFromDate: textpostfromdate.val().trim(),
            PostToDate: textposttodate.val().trim(),
            IndustryId: selectindustry.val(),
            ApplicationMethodType: selectapplicationmethod.val(),
            ApplicationToEmailId: texttoemail.val().trim(),
            ApplicationCcEmailId: textccemail.val().trim(),
            ApplicationURL: texturl.val().trim(),
            SkillIds: selectskills.val().trim(),
            SubIndustryIds: subindustries,
            JobTypeIds: jobtype,
            JobStatus: jobstatus
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/job/insertandupdatejobdetails",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showsuccessalert(data.StatusMessage);
                    $('#amyjobslist')[0].click();
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