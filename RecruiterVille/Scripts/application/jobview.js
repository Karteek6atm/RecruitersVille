function applyjob() {
    var isvalid = true;
    var textfirstname = $('#textfirstname');
    var textlastname = $('#textlastname');
    var textemailid = $('#textemailid');
    var textcontact = $('#textcontact');
    var hiddenresumefile = $("#hiddenresumefile");

    if (validatetextbox(textfirstname) == false) {
        isvalid = false;
    }
    if (validateemailid(textemailid) == false) {
        isvalid = false;
    }
    if (validatephonenumber(textcontact) == false) {
        isvalid = false;
    }
    if (validatetextbox(hiddenresumefile) == false) {
        isvalid = false;
        alert("Please upload resume");
    }

    if (isvalid) {
        showloading();

        var input = [];
        input = {
            strJobId: $("#hiddenjobid").val(),
            FirstName: textfirstname.val().trim(),
            LastName: textlastname.val().trim(),
            EmailId: textemailid.val().trim(),
            ContactNumber: textcontact.val().trim(),
            ResumePath: hiddenresumefile.val()
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/site/applyjob",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showsuccessalert(data.StatusMessage);
                }
                else {
                    showwarningalert(data.StatusMessage);
                }
                hideloading();
                $('#closemodalapplyjob').click();
            },
            error: function (xhr) {
                hideloading();
                showerroralert(xhr.responseText);
                $('#closemodalapplyjob').click();
            }
        });
    }
    else {
        return false;
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

function openapplyjobmodal() {
    $('#textfirstname').val('');
    $('#textlastname').val('');
    $('#textemailid').val('');
    $('#textcontact').val('');
    $('#hiddenresumefile').val('');
    $('#fileresume').val('')
    $('#textfirstname').closest('.form-group').removeClass("has-error");
    $('#textfirstname').closest('.form-group').removeClass("has-success");
    $('#textlastname').closest('.form-group').removeClass("has-error");
    $('#textlastname').closest('.form-group').removeClass("has-success");
    $('#textemailid').closest('.form-group').removeClass("has-error");
    $('#textemailid').closest('.form-group').removeClass("has-success");
    $('#textcontact').closest('.form-group').removeClass("has-error");
    $('#textcontact').closest('.form-group').removeClass("has-success");

    $('#modalapplyjob').modal();
}

function shareonfacebook() {
    var joburl = weburl + 'jobview/' + $('#hiddenjobid').val();
    window.open('http://www.facebook.com/sharer.php?u=' + $.trim(joburl), 'sharer', 'toolbar=0, status=0, width=626, height=436'); return false;
}

function shareontwitter() {
    var joburl = weburl + 'jobview/' + $('#hiddenjobid').val();
    var jobtitle = $('#labeljobtitle').html();
    window.open('http://twitter.com/share?text=' + $.trim(jobtitle) + '&url=' + $.trim(joburl), 'sharer', 'toolbar=0, status=0, width=626, height=436,name="twitter:image"'); return false;
}

function shareonlinkedin() {
    var joburl = weburl + 'jobview/' + $('#hiddenjobid').val();
    window.open('https://www.linkedin.com/cws/share?url=' + $.trim(joburl), 'sharer', 'toolbar=0, status=0, width=626, height=436'); return false;
}