function getvendorslist() {
    showloading();
    $('#tbodyvendors tr').remove();

    $.ajax({
        type: "GET",
        url: "/recruiter/getvendorslist",
        dataType: "json",
        success: function (data) {
            var ishavingvendors = true;

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

                        var isemployer = (data[i].IsEmployer) ? "Yes" : "No";

                        $(tr).append('<td>' + (i + 1) + '<input type="hidden" id="hiddenvendorid" value="' + data[i].VendorId + '" /></td>' +
                                    '<td>' + data[i].VendorName + '</td>' +
                                    '<td>' + data[i].EmailId + '</td>' +
                                    '<td>' + data[i].ContactNumber + '</td>' +
                                    '<td>' + isemployer + '</td>' +
                                    '<td>' + data[i].TechnologyNames + '</td>' +
                                    '<td>' + address + '</td>' +
                                    '<td><a href="javascript:void(0)" id="aeditvendor" onclick="editvendor(this)"><i class="fa fa-pencil"></i> Edit</a> &nbsp; <a href="javascript:void(0)" id="adeletevendor" onclick="deletevendor(this)"><i class="fa fa-trash-o"></i> Delete</a></td>');

                        $('#tbodyvendors').append(tr);
                    }
                }
                else {
                    ishavingvendors = false;
                }
            }
            else {
                ishavingvendors = false;
            }

            if (!ishavingvendors) {
                var tr = $('<tr />');
                $(tr).append('<td colspan="8">No vendors found in your company.</td>');
                $('#tbodyvendors').append(tr);
            }

            hideloading();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
}

function addnewvendor() {
    clearfields();
    $("#hiddenselectedvendorid").val('0');
    $('#textvendoremailid').removeAttr('disabled');
    $('#modalvendorcreation').modal();
}

function clearfields() {
    $('#textvendorname').val('');
    $('#textvendoremailid').val('');
    $('#textvendorcontact').val('');
    $('#filevendorlogo').val('');
    $('#hiddenvendorlogo').val('');
    $('#radioisemployeryes')[0].checked = true;
    $('#textvendorstreet').val('');
    $('#textvendorcity').val('');
    $('#textvendorstate').val('');
    $('#textvendorcountry').val('');
    $('#textvendorzipcode').val('');
    $('#textvendorlandmark').val('');
    $('#textdescription').val('');
    $('#selecttechnologies').val('');

    //var technologiesoptions = $('#selecttechnologies option');

    //for (var i = 0; i < technologiesoptions.length; i++) {
    //    $(technologiesoptions[i]).attr('selected', false);
    //}

    //$('.multiple-select').fSelect('reload');

    $('.has-error').removeClass("has-error");
    $('.has-success').removeClass("has-success");
}

function editvendor(obj) {
    clearfields();
    showloading();
    var vendorid = $(obj).closest('tr').find('#hiddenvendorid').val();

    if (vendorid != "" || vendorid != "0") {
        $.ajax({
            type: "GET",
            url: "/recruiter/getvendordetailsbyid/" + parseInt(vendorid),
            dataType: "json",
            success: function (data) {
                if (data != null) {
                    //$(".multiple-select").fSelect('destroy');

                    $("#hiddenselectedvendorid").val(vendorid);
                    $('#textvendoremailid').attr('disabled', 'disabled');

                    $('#textvendorname').val(data.VendorName);
                    $('#textvendoremailid').val(data.EmailId);
                    $('#textvendorcontact').val(data.ContactNumber);
                    //$('#filevendorlogo').val(data.VendorLogoPath);
                    $('#hiddenvendorlogo').val(data.VendorLogoPath);
                    if (data.IsEmployer) {
                        $('#radioisemployeryes')[0].checked = true;
                    }
                    else {
                        $('#radioisemployerno')[0].checked = true;
                    }
                    $('#textvendorstreet').val(data.Street);
                    $('#textvendorcity').val(data.City);
                    $('#textvendorstate').val(data.State);
                    $('#textvendorcountry').val(data.Country);
                    $('#textvendorzipcode').val(data.Zipcode);
                    $('#textvendorlandmark').val(data.Landmark);
                    $('#textdescription').val(data.Description);
                    $('#selecttechnologies').val(data.TechnologyIds);

                    //var technologiesoptions = $('#selecttechnologies option');
                    //var technologyids = data.TechnologyIds.split(',');

                    //for (var i = 0; i < technologiesoptions.length; i++) {
                    //    var selectedvalue = technologiesoptions[i].value;

                    //    if ($.inArray(selectedvalue, technologyids) > -1) {
                    //        $(technologiesoptions[i]).attr('selected', true);
                    //    }
                    //}

                    //$('.multiple-select').fSelect('reload');
                    $('#modalvendorcreation').modal();
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

function uploadcompanylogo() {
    var filevendorlogo = $('#filevendorlogo');

    if (validateimage(filevendorlogo) == false) {
        return false;
    }
    else {
        var formdata = new FormData();
        var file = document.getElementById('filevendorlogo').files[0]
        if (formdata) {
            formdata.append("file", file);
            $.ajax({
                url: "/recruiter/uploadcompanylogo",
                type: "POST",
                data: formdata,
                processData: false,
                contentType: false,
                success: function (data) {
                    $('#hiddenvendorlogo').val(data.imagepath);
                }
            });
        }
    }
}

function savevendordetails() {
    hideallalerts();
    var vendorid = $("#hiddenselectedvendorid").val();
    var textvendorname = $("#textvendorname");
    var textvendoremailid = $("#textvendoremailid");
    var textvendorcontact = $("#textvendorcontact");
    var filevendorlogo = $("#filevendorlogo");
    var hiddenvendorlogo = $("#hiddenvendorlogo");
    var radioisemployeryes = $("#radioisemployeryes");
    var radioisemployerno = $("#radioisemployerno");
    var textvendorstreet = $("#textvendorstreet");
    var textvendorcity = $("#textvendorcity");
    var textvendorstate = $("#textvendorstate");
    var textvendorcountry = $("#textvendorcountry");
    var textvendorzipcode = $("#textvendorzipcode");
    var textvendorlandmark = $("#textvendorlandmark");
    var textdescription = $("#textdescription");
    var selecttechnologies = $("#selecttechnologies");

    var isvalid = true;
    var isemployer = false;
    //var technologies = getmultiselectedvalues(selecttechnologies);

    //if (validatetextbox(textvendorname) == false) {
    //    isvalid = false;
    //}
    if (validateemailid(textvendoremailid) == false) {
        isvalid = false;
    }
    //if (validatephonenumber(textvendorcontact) == false) {
    //    isvalid = false;
    //}
    //if (validatetextbox(hiddenvendorlogo) == false) {
    //    isvalid = false;
    //}
    //if (validatetextbox(selecttechnologies) == false) {
    //    isvalid = false;
    //}
    //if (technologies == "") {
    //    $(selecttechnologies).closest('.form-group').addClass("has-error");
    //    $(selecttechnologies).closest('.form-group').removeClass("has-success");
    //    isvalid = false;
    //}
    //else {
    //    $(selecttechnologies).closest('.form-group').removeClass("has-error");
    //    $(selecttechnologies).closest('.form-group').addClass("has-success");
    //}
    if (radioisemployeryes[0].checked) {
        isemployer = true;
    }

    if (isvalid) {
        showloading();

        var input = [];
        input = {
            VendorId: (vendorid == "") ? 0 : vendorid,
            VendorName: textvendorname.val().trim(),
            EmailId: textvendoremailid.val().trim(),
            ContactNumber: textvendorcontact.val().trim(),
            IsEmployer: isemployer,
            Description: textdescription.val().trim(),
            VendorLogoPath: hiddenvendorlogo.val().trim(),
            Street: textvendorstreet.val().trim(),
            Landmark: textvendorlandmark.val().trim(),
            City: textvendorcity.val().trim(),
            State: textvendorstate.val().trim(),
            Country: textvendorcountry.val().trim(),
            Zipcode: textvendorzipcode.val().trim(),
            Technologies: selecttechnologies.val().trim()
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/recruiter/insertandupdatevendordetails",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showsuccessalert(data.StatusMessage);
                    $("#hiddenselectedvendorid").val('0');
                    $('#closemodalvendorcreation').click();
                    getvendorslist();
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

function deletevendor(obj) {
    var vendorid = $(obj).closest('tr').find('#hiddenvendorid').val();
    $("#hiddenselectedvendorid").val(vendorid);
    $('#modaldeletevendor').modal();
}

function deletevendorconfirm() {
    hideallalerts();
    var vendorid = $("#hiddenselectedvendorid").val();

    if (vendorid != "" || vendorid != "0") {
        $.ajax({
            type: "GET",
            url: "/recruiter/deletevendordetails/" + parseInt(vendorid),
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showsuccessalert(data.StatusMessage);
                    $("#hiddenselectedvendorid").val('0');
                    $('#closemodaldeletevendor').click();
                    getvendorslist();
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

var importedvendors = [];

function uploadvendorsfile() {
    var filevendorfile = $('#filevendorfile');
    importedvendors = [];

    if (validateexcelfileformat(filevendorfile) == false) {
        return false;
    }
    else {
        var formdata = new FormData();
        var file = document.getElementById('filevendorfile').files[0]
        if (formdata) {
            $('#tbodyimportedvendors tr').remove();
            formdata.append("file", file);
            $.ajax({
                url: "/recruiter/uploadvendors",
                type: "POST",
                data: formdata,
                processData: false,
                contentType: false,
                dataType: "json",
                success: function (data) {
                    if (data.length > 0) {
                        $('#hiddenvendorfile').val(data[0].FilePath);
                        
                        for (var i = 0; i < data.length; i++) {
                            var tr = $('<tr />');

                            var isvalidrecord = 'No';
                            var isemployer = false;

                            if (data[i].IsValid) {
                                isvalidrecord = 'Yes';
                            }
                            if (data[i].IsEmployer.trim() == "yes" || data[i].IsEmployer.trim() == "Yes") {
                                isemployer = true;
                            }

                            $(tr).append('<td><span id="sno">' + data[i].Sno + '</span></td>' +
                                        '<td><span id="isvalid" style="display:none;">' + data[i].IsValid + '</span>' + isvalidrecord + '</td>' +
                                        '<td><span id="vendorname">' + data[i].VendorName + '</span></td>' +
                                        '<td><span id="emailid">' + data[i].EmailId + '</span></td>' +
                                        '<td><span id="contactnumber">' + data[i].ContactNumber + '</span></td>' +
                                        '<td><span id="isemployer"style="display:none;">' + isemployer + '</span>' + data[i].IsEmployer + '</td>' +
                                        '<td><span id="technologies">' + data[i].Technologies + '</span></td>' +
                                        '<td><span id="street">' + data[i].Street + '</span></td>' +
                                        '<td><span id="landmark">' + data[i].Landmark + '</span></td>' +
                                        '<td><span id="city">' + data[i].City + '</span></td>' +
                                        '<td><span id="state">' + data[i].State + '</span></td>' +
                                        '<td><span id="country">' + data[i].Country + '</span></td>' +
                                        '<td><span id="zipcode">' + data[i].Zipcode + '</span></td>' +
                                        '<td><span id="comments">' + data[i].Comments + '</span></td>');
                            $('#tbodyimportedvendors').append(tr);

                            importedvendors.push({
                                Sno : data[i].Sno,
                                VendorName : data[i].VendorName,
                                EmailId : data[i].EmailId,
                                ContactNumber : data[i].ContactNumber,
                                IsEmployer : isemployer,
                                Technologies : data[i].Technologies,
                                Street : data[i].Street,
                                Landmark : data[i].Landmark,
                                City : data[i].City,
                                State : data[i].State,
                                Country : data[i].Country,
                                Zipcode : data[i].Zipcode,
                                IsValid: data[i].IsValid,
                                Comments : data[i].Comments
                            });
                        }

                        $('#tableimportedvendors').DataTable();

                        $('#divimporteddata').css("display", "block");
                        $('#btnuploadnewfile').css("display", "inline-block");
                        $('#btnuploadproceed').css("display", "inline-block");
                        $('#divimportfile').css("display", "none");
                        $('#btnuploadfile').css("display", "none");
                    }
                    else {
                        var tr = $('<tr />');
                        $(tr).append('<td colspan="14">No data found.</td>');
                        $('#tbodyimportedvendors').append(tr);
                    }
                },
                error: function (xhr) {
                    hideloading();
                    showerroralert(xhr.responseText);
                }
            });
        }
    }
}

function openimportpopup() {
    $('#hiddenvendorfile').val('');
    $('#filevendorfile').val('');

    $('#divimporteddata').css("display", "none");
    $('#btnuploadnewfile').css("display", "none");
    $('#btnuploadproceed').css("display", "none");
    $('#divimportfile').css("display", "block");
    $('#btnuploadfile').css("display", "inline-block");

    $('#modalimportvendors').modal();
}

function uploadnewfile() {
    $('#hiddenvendorfile').val('');
    $('#filevendorfile').val('');

    $('#divimporteddata').css("display", "none");
    $('#btnuploadnewfile').css("display", "none");
    $('#btnuploadproceed').css("display", "none");
    $('#divimportfile').css("display", "block");
    $('#btnuploadfile').css("display", "inline-block");
}

function proceeduploadvendorsfile() {
    hideallalerts();
    var vendorfile = $("#hiddenvendorfile").val();

    if (vendorfile != "" && importedvendors.length > 0) {
        showloading();

        var input = [];
        input = {
            FilePath: vendorfile,
            ImportedVendors: importedvendors
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/recruiter/insertvendoruploads",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showsuccessalert(data.StatusMessage);
                    $("#hiddenvendorfile").val('');
                    $('#closemodalimportvendors').click();
                    getvendorslist();
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
