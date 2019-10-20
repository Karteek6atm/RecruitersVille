
function getProfileDetails() {
    showloading();
    var ProfileId = $("#hiddenProfileid").val();

    var input = [];
    input = {
        strProfileId: ProfileId
    }

    $.ajax({
        type: "POST",
        data: (input),
        url: "/profile/getprofileviewdetails",
        dataType: "json",
        success: function (data) {
            if (data != null) {
                $("#ProfileName").html(data.PersonalProfile.FullName + ' <a href="/profile/list" class="btn btn-primary pull-right">Profile List</a>');
                $("#Email").html(data.PersonalProfile.EmailId);
                $("#AlterNateEmail").html(data.PersonalProfile.AlternateEmailId);
                if (data.PersonalProfile.AlternateMobileNumber != "")
                {
                    $("#ContactNo").html(data.PersonalProfile.ContactNumber + " (" + data.PersonalProfile.AlternateMobileNumber + ")");

                }
                else
                {
                    $("#ContactNo").html(data.PersonalProfile.ContactNumber);

                }
                $("#Qualification").html(data.PersonalProfile.QualificationName);
                $("#Experience").html(data.PersonalProfile.Experience);
                $("#Location").html(data.PersonalProfile.Location + ", " + data.PersonalProfile.Country);
                $("#Industry").html(data.PersonalProfile.IndustryName);
                $("#Skills").html(data.PersonalProfile.Skills);
                $("#Resume").attr('href', data.PersonalProfile.Resume);
                $("#labeljobdescription").html(data.PersonalProfile.AboutMe);
                   
               
            }
            else {
                showwarningalert(data.PersonalProfile.StatusMessage);
            }

            hideloading();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
}
