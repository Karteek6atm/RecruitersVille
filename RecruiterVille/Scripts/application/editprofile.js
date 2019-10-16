function getprofiledetails() {
    showloading();
    var profileid = $("#hiddenprofileid").val();

    var input = [];
    input = {
        strProfileId: profileid
    }

    $.ajax({
        type: "POST",
        data: (input),
        url: "/profile/getprofiledetailsbyid",
        dataType: "json",
        success: function (data) {
            if (data != null) {
                $("#textfirstname").val(data.FirstName);
                $("#textlastname").val(data.LastName);
                $("#textemailid").val(data.EmailId);
                $("#textalternativeemailid").val(data.AlternateEmailId);
                $("#textcontactnumber").val(data.MobileNumber);
                $("#textalternatecontactnumber").val(data.AlternateMobileNumber);
                $("#selectqualification").val(data.QualificationId);
                $("#textexpyears").val(data.ExpYears);
                $("#textexpmonths").val(data.ExpMonths);
                $("#textlocation").val(data.Location);
                $("#selectcountry").val(data.CountryId);
                $("#selectindustry").val(data.IndustryId);
                $("#selectskills").val(data.Skills);
                $("#hiddenresumefile").val(data.Resume);
                $("#textdescription").val(data.Description);

                if (data.Experiences != null) {
                    for (var i = 0; i < data.Experiences.length; i++) {
                        var experience = data.Experiences[i];

                        var currentcompanychecked = "";

                        if (experience.IsCurrentCompany) {
                            currentcompanychecked = "checked";
                        }

                        var div = '<div class="newexp col-md-12 row">' +
                                   '<div class="col-md-4">' +
                                    '<div class="form-group">' +
                                        '<label>Company <span class="mandatory">*</span></label>' +
                                        '<input class="form-control" placeholder="" id="textexpcompanyname" value="' + experience.CompanyName + '" type="text" onblur="validatetextbox(this)" />' +
                                     '</div>' +
                                   '</div>' +
                                   '<div class="col-md-4">' +
                                    '<div class="form-group">' +
                                        '<label>Location <span class="mandatory">*</span></label>' +
                                        '<input class="form-control" placeholder="" id="textexplocation" value="' + experience.Location + '" type="text" onblur="validatetextbox(this)" />' +
                                     '</div>' +
                                   '</div>' +
                                   '<div class="col-md-4">' +
                                    '<div class="form-group">' +
                                        '<label>Designation <span class="mandatory">*</span></label>' +
                                        '<input class="form-control" placeholder="" id="textexpdesignation" value="' + experience.Designation + '" type="text" onblur="validatetextbox(this)" />' +
                                     '</div>' +
                                   '</div>' +
                                   '<div class="col-md-4">' +
                                    '<div class="form-group">' +
                                        '<label>From Date <span class="mandatory">*</span></label>' +
                                        '<input class="form-control datepicker" placeholder="" id="textexpfromdate" value="' + experience.StartDate + '" type="text" onblur="validateexpfromdate(this)" />' +
                                     '</div>' +
                                   '</div>' +
                                   '<div class="col-md-4">' +
                                    '<div class="form-group">' +
                                        '<label>To Date <span class="mandatory">*</span></label>' +
                                        '<input class="form-control datepicker" placeholder="" id="textexptodate" value="' + experience.EndDate + '" type="text" onblur="validateexptodate(this)" />' +
                                     '</div>' +
                                   '</div>' +
                                   '<div class="col-md-4">' +
                                    '<div class="form-group">' +
                                        '<label>' +
                                          '<input name="remember" type="checkbox" id="checkexpcurrentcompany" ' + currentcompanychecked + ' value="Current Company">Current Company?' +
                                        '</label>' +
                                     '</div>' +
                                     '<div class="form-group">' +
                                          '<input type="hidden" id="hiddenexperienceid" value="' + experience.ProfileExperienceId + '" />' +
                                          '<a href="javascript:void(0)" class="btn btn-danger pull-right" onclick="deleteexperience()">Delete</a>' +
                                     '</div>' +
                                   '</div>' +
                                 '</div>';

                        $('#divexperiences').append(div);
                    }
                }

                $('.datepicker').datepicker();
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

function addnewexperience() {
    var experiecnes = $('#divexperiences').find('.newexp').length;

    var div = '<div class="newexp col-md-12 row">' +
               '<div class="col-md-4">' +
                '<div class="form-group">' +
                    '<label>Company <span class="mandatory">*</span></label>' +
                    '<input class="form-control" placeholder="" id="textexpcompanyname" type="text" onblur="validatetextbox(this)" />' +
                 '</div>' +
               '</div>' +
               '<div class="col-md-4">' +
                '<div class="form-group">' +
                    '<label>Location <span class="mandatory">*</span></label>' +
                    '<input class="form-control" placeholder="" id="textexplocation" type="text" onblur="validatetextbox(this)" />' +
                 '</div>' +
               '</div>' +
               '<div class="col-md-4">' +
                '<div class="form-group">' +
                    '<label>Designation <span class="mandatory">*</span></label>' +
                    '<input class="form-control" placeholder="" id="textexpdesignation" type="text" onblur="validatetextbox(this)" />' +
                 '</div>' +
               '</div>' +
               '<div class="col-md-4">' +
                '<div class="form-group">' +
                    '<label>From Date <span class="mandatory">*</span></label>' +
                    '<input class="form-control datepicker" placeholder="" id="textexpfromdate" type="text" onblur="validateexpfromdate(this)" />' +
                 '</div>' +
               '</div>' +
               '<div class="col-md-4">' +
                '<div class="form-group">' +
                    '<label>To Date <span class="mandatory">*</span></label>' +
                    '<input class="form-control datepicker" placeholder="" id="textexptodate" type="text" onblur="validateexptodate(this)" />' +
                 '</div>' +
               '</div>' +
               '<div class="col-md-4">' +
                '<div class="form-group">' +
                    '<label>' +
                      '<input name="remember" type="checkbox" id="checkexpcurrentcompany" value="Current Company">Current Company?' +
                    '</label>' +
                 '</div>' +
                 '<div class="form-group">' +
                      '<input type="hidden" id="hiddenexperienceid" value="0" />' +
                      '<a href="javascript:void(0)" class="btn btn-danger pull-right" onclick="deleteexperience()">Delete</a>' +
                 '</div>' +
               '</div>' +
             '</div>';

    $('#divexperiences').append(div);
    $('.datepicker').datepicker();
}

function deleteexperience(obj) {
    $(obj).closest('.newexp').remove();
}

function validateexpmonths() {
    var textexpmonths = $("#textexpmonths");
    var isvalid = true;

    if (textexpmonths.val().trim() != "") {
        var months = parseInt(textexpmonths.val());

        if (months > 12) {
            isvalid = false;
            $(textexpmonths).closest('.form-group').addClass("has-error");
        }
    }
}

function validatealternativeemailid(obj) {
    var isvalid = true;

    if ($(obj).val() != "") {
        if (validateemailid(obj) == false) {
            isvalid = false;
        }
    }
}

function validatealternativephonenumber(obj) {
    var isvalid = true;

    if ($(obj).val() != "") {
        if (validatephonenumber(obj) == false) {
            isvalid = false;
        }
    }
}

function uploadresume() {
    var fileresume = $('#fileresume');

    if (validatedocument(fileresume) == false) {
        return false;
    }
    else {
        var formdata = new FormData();
        var file = document.getElementById('fileresume').files[0]
        if (formdata) {
            formdata.append("file", file);
            $.ajax({
                url: "/profile/uploadresume",
                type: "POST",
                data: formdata,
                processData: false,
                contentType: false,
                success: function (data) {
                    $('#hiddenresumefile').val(data.resumepath);
                }
            });
        }
    }
}

function validateexpfromdate(obj) {
    var textexpfromdate = $(obj).closest('.newexp').find('#textexpfromdate');
    var textexptodate = $(obj).closest('.newexp').find('#textexptodate');
    var checkexpcurrentcompany = $(obj).closest('.newexp').find('#checkexpcurrentcompany');
    var isvalid = true;
    var fromdate = textexpfromdate.val();
    var todate = textexptodate.val();

    if ($(checkexpcurrentcompany)[0].checked) {
        if (validatedate(textexpfromdate) == false) {
            isvalid = false;
        }
    }
    else {
        if (validatedate(textexpfromdate) == false) {
            isvalid = false;
        }
        if (validatedate(textexptodate) == false) {
            isvalid = false;
        }
        else if (new Date(fromdate) > new Date(todate)) {
            isvalid = false;
            $(textexpfromdate).closest('.form-group').addClass("has-error");
            $(textexptodate).closest('.form-group').addClass("has-error");
        }
    }

    return isvalid;
}

function validateexptodate(obj) {
    var textexpfromdate = $(obj).closest('.newexp').find('#textexpfromdate');
    var textexptodate = $(obj).closest('.newexp').find('#textexptodate');
    var checkexpcurrentcompany = $(obj).closest('.newexp').find('#checkexpcurrentcompany');
    var isvalid = true;
    var fromdate = textexpfromdate.val();
    var todate = textexptodate.val();

    if ($(checkexpcurrentcompany)[0].checked) {
        if (validatedate(textexpfromdate) == false) {
            isvalid = false;
        }
    }
    else {
        if (validatedate(textexpfromdate) == false) {
            isvalid = false;
        }
        if (validatedate(textexptodate) == false) {
            isvalid = false;
        }
        else if (new Date(fromdate) > new Date(todate)) {
            isvalid = false;
            $(textexpfromdate).closest('.form-group').addClass("has-error");
            $(textexptodate).closest('.form-group').addClass("has-error");
        }
    }

    return isvalid;
}

function saveprofiledetails() {
    hideallalerts();
    var profileid = $("#hiddenprofileid").val();
    var loginid = $("#hiddenloginid").val();
    var textfirstname = $("#textfirstname");
    var textlastname = $("#textlastname");
    var textemailid = $("#textemailid");
    var textalternativeemailid = $("#textalternativeemailid");
    var textcontactnumber = $("#textcontactnumber");
    var textalternatecontactnumber = $("#textalternatecontactnumber");
    var selectqualification = $("#selectqualification");
    var textexpyears = $("#textexpyears");
    var textexpmonths = $("#textexpmonths");
    var textlocation = $("#textlocation");
    var selectcountry = $("#selectcountry");
    var selectindustry = $("#selectindustry");
    var selectskills = $("#selectskills");
    var hiddenresumefile = $("#hiddenresumefile");
    var textdescription = $("#textdescription");

    var isvalid = true;

    if (validatetextbox(textfirstname) == false) {
        isvalid = false;
    }
    if (validatetextbox(textlastname) == false) {
        isvalid = false;
    }
    if (validateemailid(textemailid) == false) {
        isvalid = false;
    }
    if (validatealternativeemailid(textalternativeemailid) == false) {
        isvalid = false;
    }
    if (validatephonenumber(textcontactnumber) == false) {
        isvalid = false;
    }
    if (validatealternativephonenumber(textalternatecontactnumber) == false) {
        isvalid = false;
    }
    //if (validatedropdown(selectqualification) == false) {
    //    isvalid = false;
    //}
    //if (validatetextbox(textexpyears) == false) {
    //    isvalid = false;
    //}
    if (validateexpmonths(textexpmonths) == false) {
        isvalid = false;
    }
    //if (validatetextbox(textlocation) == false) {
    //    isvalid = false;
    //}
    //if (validatedropdown(selectcountry) == false) {
    //    isvalid = false;
    //}
    //if (validatedropdown(selectindustry) == false) {
    //    isvalid = false;
    //}
    if (validatetextbox(selectskills) == false) {
        isvalid = false;
    }
    if (validatetextbox(hiddenresumefile) == false) {
        isvalid = false;
        alert("Please upload resume");
    }

    var experiecnes = $('#divexperiences').find('.newexp');
    var ExperiencesArr = [];

    for (var i = 0; i < experiecnes.length; i++) {
        var experience = experiecnes[i];
        var isvalidexp = true;

        var hiddenexperienceid = $(experience).find("#hiddenexperienceid");
        var textexpcompanyname = $(experience).find("#textexpcompanyname");
        var textexplocation = $(experience).find("#textexplocation");
        var textexpdesignation = $(experience).find("#textexpdesignation");
        var textexpfromdate = $(experience).find("#textexpfromdate");
        var textexptodate = $(experience).find("#textexptodate");
        var checkexpcurrentcompany = $(experience).find("#checkexpcurrentcompany");
        
        if (validatetextbox(textexpcompanyname) == false) {
            isvalidexp = false;
        }
        if (validatetextbox(textexplocation) == false) {
            isvalidexp = false;
        }
        if (validatetextbox(textexpdesignation) == false) {
            isvalidexp = false;
        }
        if (validateexpfromdate(textexpfromdate) == false) {
            isvalidexp = false;
        }
        if (validateexptodate(textexptodate) == false) {
            isvalidexp = false;
        }
        if (!isvalidexp) {
            isvalid = false;
        }
        else {
            ExperiencesArr.push({
                ProfileExperienceId: hiddenexperienceid.val(),
                CompanyName: textexpcompanyname.val().trim(),
                Location: textexplocation.val().trim(),
                Designation: textexpdesignation.val().trim(),
                StartDate: textexpfromdate.val().trim(),
                EndDate: textexptodate.val().trim(),
                IsCurrentCompany: checkexpcurrentcompany[0].checked
            });
        }
    }

    if (isvalid) {
        showloading();

        var input = [];
        input = {
            strProfileId: profileid,
            FirstName: textfirstname.val().trim(),
            LastName: textlastname.val().trim(),
            EmailId: textemailid.val().trim(),
            AlternateEmailId: textalternativeemailid.val().trim(),
            MobileNumber: textcontactnumber.val().trim(),
            AlternateMobileNumber: textalternatecontactnumber.val().trim(),
            EducationalQualification: selectqualification.val(),
            ExpYears: textexpyears.val().trim(),
            ExpMonths: textexpmonths.val().trim(),
            Location: textlocation.val().trim(),
            Country: selectcountry.val(),
            Industry: selectindustry.val(),
            Description: textdescription.val().trim(),
            Resume: hiddenresumefile.val(),
            Skills: selectskills.val().trim(),
            Experiences: ExperiencesArr,
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/profile/insertandupdateprofiledetails",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showsuccessalert(data.StatusMessage);
                    window.location = "/profile/list";
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