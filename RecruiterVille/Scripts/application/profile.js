function getprofiledetails() {
    hideallalerts();
    showloading();

    if ($('#hiddenroleid').val() != "1") {
        $('#acompanyupdate').removeAttr("onclick");
    }

    $.ajax({
        type: "GET",
        url: "/recruiter/getprofiledetails",
        dataType: "json",
        success: function (data) {
            if (data != null) {
                personaldetails = data.PersonalProfile;
                companydetails = data.CompanyProfile;
                professionaldetails = data.ProfessionalProfile;

                if (personaldetails != null) {
                    $('#hiddenuserid').val(personaldetails.UserId);
                    $('#textuserfullname').val(personaldetails.FullName);
                    $('#textuseremailid').val(personaldetails.EmailId);
                    $('#textusercontact').val(personaldetails.ContactNumber);
                    $('#hiddenprofilepic').val(personaldetails.ProfilePicPath);
                    $('#textuserstreet').val(personaldetails.Street);
                    $('#textusercity').val(personaldetails.City);
                    $('#textuserstate').val(personaldetails.State);
                    $('#textusercountry').val(personaldetails.Country);
                    $('#textuserzipcode').val(personaldetails.Zipcode);
                    $('#textuserlandmark').val(personaldetails.Landmark);
                    $('#textaboutme').val(personaldetails.AboutMe);
                }

                if (companydetails != null) {
                    $('#hiddencompanyid').val(companydetails.CompanyId);
                    $('#textcompanyname').val(companydetails.CompanyName);
                    $('#hiddencompanylogo').val(companydetails.CompanyLogoPath);
                    $('#textcompanystreet').val(companydetails.Street);
                    $('#textcompanycity').val(companydetails.City);
                    $('#textcompanystate').val(companydetails.State);
                    $('#textcompanycountry').val(companydetails.Country);
                    $('#textcompanyzipcode').val(companydetails.Zipcode);
                    $('#textcompanylandmark').val(companydetails.Landmark);
                    $('#textaboutcompany').val(companydetails.AboutCompany);
                }

                if (professionaldetails != null) {
                    $('#hiddenprofessionalid').val(professionaldetails.UserProfessionId);
                    //$('#textprofessionalcompanyname').val(professionaldetails.CompanyName);
                    $('#textprofessionalworkstartedate').val(professionaldetails.CurrentCompanyWorkStartDate);
                    $('#selectprofessionalexperience').val(professionaldetails.Experience);
                    $('#textprofessionalachievements').val(professionaldetails.Achievements);
                    $('#textprofessionaldesignation').val(professionaldetails.Designation);
                    $('#textaboutprofessional').val(professionaldetails.Description);
                    $('#selectprofessionalskills').val(professionaldetails.TechnologyIds);

                    var professionalhiringleveloptions = $('#selectprofessionalhiringlevel option');
                    var professionalhiringlevels = professionaldetails.HiringForIds.split(',');

                    for (var i = 0; i < professionalhiringleveloptions.length; i++) {
                        var selectedvalue = professionalhiringleveloptions[i].value;

                        if ($.inArray(selectedvalue, professionalhiringlevels) > -1) {
                            $(professionalhiringleveloptions[i]).attr('selected', true);
                        }
                    }

                    var professionalindustriesoptions = $('#selectprofessionalindustries option');
                    var professionalindustries = professionaldetails.IndustryIds.split(',');

                    for (var i = 0; i < professionalindustriesoptions.length; i++) {
                        var selectedvalue = professionalindustriesoptions[i].value;

                        if ($.inArray(selectedvalue, professionalindustries) > -1) {
                            $(professionalindustriesoptions[i]).attr('selected', true);
                        }
                    }

                    var professionalfunctionalareasoptions = $('#selectprofessionalfunctionalareas option');
                    var functionalareas = professionaldetails.FunctionalAreas.split(',');

                    for (var i = 0; i < professionalfunctionalareasoptions.length; i++) {
                        var selectedvalue = professionalfunctionalareasoptions[i].value;

                        if ($.inArray(selectedvalue, functionalareas) > -1) {
                            $(professionalfunctionalareasoptions[i]).attr('selected', true);
                        }
                    }

                    //var professionalskills = $('#selectprofessionalskills option');
                    //var technologyids = professionaldetails.TechnologyIds.split(',');

                    //for (var i = 0; i < professionalskills.length; i++) {
                    //    var selectedvalue = professionalskills[i].value;

                    //    if ($.inArray(selectedvalue, technologyids) > -1) {
                    //        $(professionalskills[i]).attr('selected', true);
                    //    }
                    //}
                }
            }

            hideloading();
            $('.multiple-select').fSelect();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
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

function uploadcompanylogo() {
    var filecompanylogo = $('#filecompanylogo');

    if (validateimage(filecompanylogo) == false) {
        return false;
    }
    else {
        var formdata = new FormData();
        var file = document.getElementById('filecompanylogo').files[0]
        if (formdata) {
            formdata.append("file", file);
            $.ajax({
                url: "/recruiter/uploadcompanylogo",
                type: "POST",
                data: formdata,
                processData: false,
                contentType: false,
                success: function (data) {
                    $('#hiddencompanylogo').val(data.imagepath);
                }
            });
        }
    }
}

function updatepersonaldetails() {
    hideallalerts();
    var loginid = $("#hiddenloginid").val();
    var textuserfullname = $("#textuserfullname");
    var textuseremailid = $("#textuseremailid");
    var textusercontact = $("#textusercontact");
    var fileprofilepicture = $("#fileprofilepicture");
    var hiddenprofilepic = $("#hiddenprofilepic");
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
    if (validatetextbox(textaboutme) == false) {
        isvalid = false;
    }
    if (validatetextbox(hiddenprofilepic) == false) {
        //$(hiddenprofilepic).closest('.form-group').removeClass("has-error");
        isvalid = false;
    }

    if (isvalid) {
        showloading();

        var input = [];
        input = {
            FullName: textuserfullname.val().trim(),
            ContactNumber: textusercontact.val().trim(),
            AboutMe: textaboutme.val().trim(),
            ProfilePicPath: hiddenprofilepic.val().trim(),
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
            url: "/recruiter/updateuserpersonaldetails",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showsuccessalert(data.StatusMessage);

                    if (hiddenprofilepic.val().trim() != "") {
                        $('#imgprofilepic').attr("src", hiddenprofilepic.val().trim());
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

function updatecompanydetails() {
    hideallalerts();
    var loginid = $("#hiddenloginid").val();
    var companyid = $("#hiddencompanyid").val();
    var textcompanyname = $("#textcompanyname");
    var hiddencompanylogo = $("#hiddencompanylogo");
    var filecompanylogo = $("#filecompanylogo");
    var textcompanystreet = $("#textcompanystreet");
    var textcompanycity = $("#textcompanycity");
    var textcompanystate = $("#textcompanystate");
    var textcompanycountry = $("#textcompanycountry");
    var textcompanyzipcode = $("#textcompanyzipcode");
    var textcompanylandmark = $("#textcompanylandmark");
    var textaboutcompany = $("#textaboutcompany");

    var isvalid = true;

    if (validatetextbox(textcompanyname) == false) {
        isvalid = false;
    }
    if (validatetextbox(textaboutcompany) == false) {
        isvalid = false;
    }
    if (validatetextbox(hiddencompanylogo) == false) {
        //$(hiddencompanylogo).closest('.form-group').addClass("has-error");
        isvalid = false;
    }

    if (isvalid) {
        showloading();

        var input = [];
        input = {
            CompanyId: companyid,
            CompanyName: textcompanyname.val().trim(),
            AboutCompany: textaboutcompany.val().trim(),
            CompanyLogoPath: hiddencompanylogo.val().trim(),
            Street: textcompanystreet.val().trim(),
            Landmark: textcompanylandmark.val().trim(),
            City: textcompanycity.val().trim(),
            State: textcompanystate.val().trim(),
            Country: textcompanycountry.val().trim(),
            Zipcode: textcompanyzipcode.val().trim()
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/recruiter/updatecompanydetails",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showsuccessalert(data.StatusMessage);

                    $("#textprofessionalcompanyname").val(textcompanyname.val().trim());
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

function updateprofessionaldetails() {
    hideallalerts();
    var loginid = $("#hiddenloginid").val();
    var textprofessionalworkstartedate = $("#textprofessionalworkstartedate");
    var selectprofessionalexperience = $("#selectprofessionalexperience");
    var selectprofessionalhiringlevel = $("#selectprofessionalhiringlevel");
    var selectprofessionalindustries = $("#selectprofessionalindustries");
    var selectprofessionalfunctionalareas = $("#selectprofessionalfunctionalareas");
    var selectprofessionalskills = $("#selectprofessionalskills");
    var textprofessionalachievements = $("#textprofessionalachievements");
    var textprofessionaldesignation = $("#textprofessionaldesignation");
    var textaboutprofessional = $("#textaboutprofessional");

    var isvalid = true;
    var professionalhiringlevel = getmultiselectedvalues(selectprofessionalhiringlevel);
    var professionalindustries = getmultiselectedvalues(selectprofessionalindustries);
    var professionalfunctionalareas = getmultiselectedvalues(selectprofessionalfunctionalareas);
    //var professionalskills = getmultiselectedvalues(selectprofessionalskills);

    if (validatetextbox(textprofessionalworkstartedate) == false) {
        isvalid = false;
    }
    if (validatedropdown(selectprofessionalexperience) == false) {
        isvalid = false;
    }
    if (validatetextbox(textprofessionaldesignation) == false) {
        isvalid = false;
    }
    if (validatetextbox(selectprofessionalskills) == false) {
        isvalid = false;
    }
    if (professionalhiringlevel == "") {
        $(selectprofessionalhiringlevel).closest('.form-group').addClass("has-error");
        $(selectprofessionalhiringlevel).closest('.form-group').removeClass("has-success");
        isvalid = false;
    }
    else {
        $(selectprofessionalhiringlevel).closest('.form-group').removeClass("has-error");
        $(selectprofessionalhiringlevel).closest('.form-group').addClass("has-success");
    }
    if (professionalindustries == "") {
        $(selectprofessionalindustries).closest('.form-group').addClass("has-error");
        $(selectprofessionalindustries).closest('.form-group').removeClass("has-success");
        isvalid = false;
    }
    else {
        $(selectprofessionalindustries).closest('.form-group').removeClass("has-error");
        $(selectprofessionalindustries).closest('.form-group').addClass("has-success");
    }
    if (professionalfunctionalareas == "") {
        $(selectprofessionalfunctionalareas).closest('.form-group').addClass("has-error");
        $(selectprofessionalfunctionalareas).closest('.form-group').removeClass("has-success");
        isvalid = false;
    }
    else {
        $(selectprofessionalfunctionalareas).closest('.form-group').removeClass("has-error");
        $(selectprofessionalfunctionalareas).closest('.form-group').addClass("has-success");
    }
    //if (professionalskills == "") {
    //    $(selectprofessionalskills).closest('.form-group').addClass("has-error");
    //    $(selectprofessionalskills).closest('.form-group').removeClass("has-success");
    //    isvalid = false;
    //}
    //else {
    //    $(selectprofessionalskills).closest('.form-group').removeClass("has-error");
    //    $(selectprofessionalskills).closest('.form-group').addClass("has-success");
    //}

    if (isvalid) {
        showloading();

        var input = [];
        input = {
            Designation: textprofessionaldesignation.val().trim(),
            CurrentCompanyWorkStartDate: textprofessionalworkstartedate.val().trim(),
            Experience: selectprofessionalexperience.val().trim(),
            Description: textaboutprofessional.val().trim(),
            Achievements: textprofessionalachievements.val().trim(),
            HiringLevels: professionalhiringlevel,
            Industries: professionalindustries,
            FunctionalAreas: professionalfunctionalareas,
            Skills: selectprofessionalskills.val().trim()
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/recruiter/updateuserprofessionaldetails",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
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

function validatepassword(obj) {
    if (validatetextbox(obj) == false) {
        return false;
    }
    else if (checkpasswordcriteria(obj) == false) {
        return false;
    }
}

function validateconfirmpassword(obj) {
    var textpassword = $("#textnewpassword");
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

function updatepassword() {
    hideallalerts();
    var loginid = $("#hiddenloginid").val();
    var textoldpassword = $("#textoldpassword");
    var textnewpassword = $("#textnewpassword");
    var textconfirmpassword = $("#textconfirmpassword");

    var isvalid = true;

    if (validatetextbox(textoldpassword) == false) {
        isvalid = false;
    }
    if (validatepassword(textnewpassword) == false) {
        isvalid = false;
    }
    if (validateconfirmpassword(textconfirmpassword) == false) {
        isvalid = false;
    }

    if (isvalid) {
        showloading();

        var input = [];
        input = {
            OldPassword: textoldpassword.val().trim(),
            NewPassword: textnewpassword.val().trim()
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/recruiter/updateuserpassword",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showsuccessalert(data.StatusMessage);

                    window.location = "/account/logout";
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