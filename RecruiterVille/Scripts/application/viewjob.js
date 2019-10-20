function getjobdetails() {
    showloading();

    var input = [];
    input = {
        strJobId: $('#hiddenselectedjobid').val().trim()
    }

    $.ajax({
        type: "POST",
        data: (input),
        url: "/job/getjobdetailsbyidforview",
        dataType: "json",
        success: function (data) {
            if (data != null) {
                $('#labeljobtitle').html(data.JobTitle);
                $('#labelcompanyjobid').html(data.CompanyJobId);
                $('#labeljoblocation').html(data.JobLocation);

                var experience = '';
                var pay = '';
                var duration = '';
                var travelallowances = '';
                var wfhavailable = 'No';
                var applicationmethod = '';
                var postdates = '';

                if (data.MinPayRate > 0 || data.MaxPayRate > 0) {
                    pay = data.PayCurrencySign + ' ' + data.MinPayRate + ' - ' + data.MaxPayRate + ' / ' + data.PayTypeName;
                }

                if (data.JobDuration > 0) {
                    duration = data.JobDuration + ' ' + data.JobDurationTypeName;
                }

                if (data.MinExp > 0 && data.MaxExp > 0) {
                    experience = data.MinExp + ' to ' + data.MaxExp + ' Yrs';
                }
                else if (data.MinExp > 0) {
                    experience = data.MinExp + ' Yrs';
                }
                else if (data.MaxExp > 0) {
                    experience = data.MaxExp + ' Yrs';
                }

                if (data.TravelAllowances > 0) {
                    travelallowances = data.TravelAllowances + ' ' + data.TravelRequirementName;
                }

                if (data.IsWFHAvailable) {
                    wfhavailable = 'Yes';
                }

                if (data.ApplicationMethodTypeName != '') {
                    applicationmethod = data.ApplicationMethodTypeName;
                    if (data.URL != '') {
                        applicationmethod = applicationmethod + '<br />' + 'URL : ' + data.URL;
                    }
                    else {
                        applicationmethod = applicationmethod + '<br />' + 'To EmailId : ' + data.ToEmailId;
                        applicationmethod = applicationmethod + '<br />' + 'CC EmailId : ' + data.CcEmailId;
                    }
                }

                if (data.PostFromDate != '' && data.PostToDate != '') {
                    postdates = data.PostFromDate + ' to ' + data.PostToDate;
                }
                else if (data.PostFromDate != '') {
                    postdates = data.PostFromDate;
                }
                else if (data.PostToDate != '') {
                    postdates = data.PostToDate;
                }

                $('#labelpay').html(pay);
                $('#labelduration').html(duration);
                $('#labelexperience').html(experience);
                $('#labeljobtypes').html(data.JobTypeNames);
                $('#labelindustry').html(data.IndustryName);
                $('#labelsubindustries').html(data.SubIndustryNames);
                $('#labelskills').html(data.TechnologyNames);
                $('#labeltravelallowances').html(travelallowances);
                $('#labelwfhavailable').html(wfhavailable);
                $('#labelapplicationmethod').html(applicationmethod);
                $('#labelpostdates').html(postdates);
                $('#labeljobstatus').html(data.JobStatus);
                $('#labeljobdescription').html(data.JobDescription);
            }
            hideloading();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
}

function shareonfacebook() {
    var joburl = weburl + 'jobview/' + $('#hiddenselectedjobid').val();
    window.open('http://www.facebook.com/sharer.php?u=' + $.trim(joburl), 'sharer', 'toolbar=0, status=0, width=626, height=436'); return false;
}

function shareontwitter() {
    var joburl = weburl + 'jobview/' + $('#hiddenselectedjobid').val();
    var jobtitle = $('#labeljobtitle').html();
    window.open('http://twitter.com/share?text=' + $.trim(jobtitle) + '&url=' + $.trim(joburl), 'sharer', 'toolbar=0, status=0, width=626, height=436,name="twitter:image"'); return false;
}

function shareonlinkedin() {
    var joburl = weburl + 'jobview/' + $('#hiddenselectedjobid').val();
    window.open('https://www.linkedin.com/cws/share?url=' + $.trim(joburl), 'sharer', 'toolbar=0, status=0, width=626, height=436'); return false;
}