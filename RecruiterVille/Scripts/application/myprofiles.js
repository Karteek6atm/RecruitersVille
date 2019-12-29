function getprofileslist() {
    showloading();
    $('#tbodyprofiles tr').remove();
    
    var selectqualification = $("#selectqualification");
    var selectindustry = $("#selectindustry");
    var textminexp = $("#textminexp");
    var textmaxexp = $("#textmaxexp");
    var textlocation = $("#textlocation");
    var selectskills = $("#selectskills");

    var industryids = getmultiselectedvalues(selectindustry);
    var qualificationids = getmultiselectedvalues(selectqualification);
    var minexp = (textminexp.val() == "") ? 0 : textminexp.val();
    var maxexp = (textmaxexp.val() == "") ? 0 : textmaxexp.val();
         
    var input = [];
    input = {
        IndustryIds: industryids,
        QualificationIds: qualificationids,
        MinExperience: minexp,
        MaxExperience: maxexp,
        Location: textlocation.val().trim(),
        Skills: selectskills.val().trim()
    };

    $.ajax({
        type: "POST",
        data: (input),
        url: "/profile/getprofileslist",
        dataType: "json",
        success: function (data) {
            var ishavingprofiles = true;

            if (data != null) {
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        var tr = $('<tr />');
                        var name = data[i].FirstName;

                        if(data[i].LastName!=""){
                            name = name + " " + data[i].LastName;
                        }

                        var experience = '';

                        if (data[i].ExpYears == 0 && data[i].ExpMonths == 0) {
                            experience = 'Fresher';
                        }
                        else if (data[i].ExpMonths == 0) {
                            experience = data[i].ExpYears + ' Years';
                        }
                        else if (data[i].ExpYears == 0) {
                            experience = data[i].ExpMonths + ' Months';
                        }
                        else {
                            experience = data[i].ExpYears + ' Years - ' + data[i].ExpMonths + ' Months';
                        }

                        $(tr).append('<td>' + (i + 1) + '<input type="hidden" id="hiddenprofileid" value="' + data[i].ProfileId + '" /></td>' +
                                    '<td>' + name + '</td>' +
                                    '<td>' + data[i].EmailId + '</td>' +
                                    '<td>' + data[i].MobileNumber + '</td>' +
                                    '<td>' + experience + '</td>' +
                                    '<td>' + data[i].Industry + '</td>' +
                                    '<td>' + data[i].Skills + '</td>' +
                                    '<td><a href="' + data[i].Resume + '" target="_blank" id="aresumedownload"> Download</a></td>' +
                                    '<td><a href="/profile/edit/' + data[i].ProfileId + '" id="aeditprofile"> <i class="fa fa-pencil"></i> Edit</a> &nbsp; <a href="javascript:void(0)" id="achangeprofilestatus" onclick="changeprofilestatus(this)"><i class="fa fa-trash-o"></i> Change Status</a>' +
                                    ' &nbsp; <a href="/profile/view/' + data[i].ProfileId + '" id="aviewprofile"><i class="fa fa-eye"></i> View</a></td>');

                        $('#tbodyprofiles').append(tr);
                    }
                }
                else {
                    ishavingprofiles = false;
                }
            }
            else {
                ishavingprofiles = false;
            }

            if (!ishavingprofiles) {
                var tr = $('<tr />');
                $(tr).append('<td colspan="9">No profiles found.</td>');
                $('#tbodyprofiles').append(tr);
            }

            hideloading();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
}

function changeprofilestatus(obj) {

}

var importedprofiles = [];

function uploadprofilesfile() {
    var fileprofilefile = $('#fileprofilefile');
    importedprofiles = [];

    if (validateexcelfileformat(fileprofilefile) == false) {
        return false;
    }
    else {
        var formdata = new FormData();
        var file = document.getElementById('fileprofilefile').files[0]
        if (formdata) {
            $('#tbodyimportedprofiles tr').remove();
            formdata.append("file", file);
            $.ajax({
                url: "/profile/uploadprofiles",
                type: "POST",
                data: formdata,
                processData: false,
                contentType: false,
                dataType: "json",
                success: function (data) {
                    if (data.length > 0) {
                        $('#hiddenprofilefile').val(data[0].FilePath);

                        for (var i = 0; i < data.length; i++) {
                            var tr = $('<tr />');

                            var isvalidrecord = 'No';

                            if (data[i].IsValid) {
                                isvalidrecord = 'Yes';
                            }

                            $(tr).append('<td><span id="sno">' + data[i].Sno + '</span></td>' +
                                        '<td><span id="isvalid" style="display:none;">' + data[i].IsValid + '</span>' + isvalidrecord + '</td>' +
                                        '<td><span id="firstname">' + data[i].FirstName + '</span></td>' +
                                        '<td><span id="lastname">' + data[i].LastName + '</span></td>' +
                                        '<td><span id="emailid">' + data[i].EmailId + '</span></td>' +
                                        '<td><span id="contactnumber">' + data[i].ContactNumber + '</span></td>' +
                                        '<td><span id="experience">' + data[i].Experience + '</span></td>' +
                                        '<td><span id="location">' + data[i].Location + '</span></td>' +
                                        '<td><span id="skills">' + data[i].Skills + '</span></td>' +
                                        '<td><span id="aboutprofile">' + data[i].AboutProfile + '</span></td>' +
                                        '<td><span id="comments">' + data[i].Comments + '</span></td>');
                            $('#tbodyimportedprofiles').append(tr);
                            
                            importedprofiles.push({
                                Sno: data[i].Sno,
                                FirstName: data[i].FirstName,
                                LastName: data[i].LastName,
                                EmailId: data[i].EmailId,
                                ContactNumber: data[i].ContactNumber,
                                Location: data[i].Location,
                                Experience: data[i].Experience,
                                Skills: data[i].Skills,
                                AboutProfile: data[i].AboutProfile,
                                IsValid: data[i].IsValid,
                                Comments: data[i].Comments
                            });
                        }

                        $('#tableimportedprofiles').DataTable();

                        $('#divimporteddata').css("display", "block");
                        $('#btnuploadnewfile').css("display", "inline-block");
                        $('#btnuploadproceed').css("display", "inline-block");
                        $('#divimportfile').css("display", "none");
                        $('#btnuploadfile').css("display", "none");
                    }
                    else {
                        var tr = $('<tr />');
                        $(tr).append('<td colspan="11">No data found.</td>');
                        $('#tbodyimportedprofiles').append(tr);
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
    $('#hiddenprofilefile').val('');
    $('#fileprofilefile').val('');

    $('#divimporteddata').css("display", "none");
    $('#btnuploadnewfile').css("display", "none");
    $('#btnuploadproceed').css("display", "none");
    $('#divimportfile').css("display", "block");
    $('#btnuploadfile').css("display", "inline-block");

    $('#modalimportprofiles').modal();
}

function uploadnewfile() {
    $('#hiddenprofilefile').val('');
    $('#fileprofilefile').val('');

    $('#divimporteddata').css("display", "none");
    $('#btnuploadnewfile').css("display", "none");
    $('#btnuploadproceed').css("display", "none");
    $('#divimportfile').css("display", "block");
    $('#btnuploadfile').css("display", "inline-block");
}

function proceeduploadprofilesfile() {
    hideallalerts();
    var profilefile = $("#hiddenprofilefile").val();

    if (profilefile != "" && importedprofiles.length > 0) {
        showloading();

        var input = [];
        input = {
            FilePath: profilefile,
            ImportedProfiles: importedprofiles
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/profile/insertprofileuploads",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showsuccessalert(data.StatusMessage);
                    $("#hiddenprofilefile").val('');
                    $('#closemodalimportprofiles').click();
                    getprofileslist();
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