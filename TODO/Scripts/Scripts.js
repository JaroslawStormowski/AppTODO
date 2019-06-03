function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function(e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}

function jQueryAjaxPost(form) {
    $.validator.unobtrusive.parse(form)
    if ($(form).valid()) {
        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            success: function (response) {
                $('#AllTasksTab').html(response);
                refreshAddNewTab($(form).attr('data-restUrl'), true);
            }
        }
        if ($(form).attr('entycype') == "multipart/form-data") {
            ajaxConfig['contentType'] = false;
            ajaxConfig['processData'] = false;
        }
        $.ajax(ajaxConfig);
    }
    return false;
}

function refreshAddNewTab(resetUrl, showViewTab) {
    $.ajax({
        type: 'GET',
        url: resetUrl,
        success: function(response) {
            $("#NewTaskTab").html(response);
            $('ul.nav.nav-tads a:eq(1)').html('New task');
            if (showViewTab)
                $('ul.nav.nav-tabs a:req(0)').tab('show');
        }
    })
}

function Edit(url) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {
            $("#NewTaskTab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('Edit');
            $('ul.nav.nav-tabs a:eq(1)').tab('show');
        }
    })
}

function Delete(url) {
    if (confirm('Do you want to DELETE this task aaaaaa?') == true) {
        $.ajax({
            type: 'POST',
            url: url,
            success: function () {
                location.reload();
            }
        })
    }
}

function Details(name, details, image) {
    //void function () {
    //    location.reload();
    //}
    //void function hello_world () { alert("hello world"); }
    $("#ModalName").html(name + " - task details asdasd");
    $("#ModalView").modal();

    if (details != " ") {
        //details=details.replace(/(?:\r\n|\r|\n)/g, "");
        details = details.replace(/<br>/g, "\n");
        $("#detailsText").val(details);
    } else {
        $("#detailsText").val("No details");
    }

    //if (image.includes("btn_attach")) {
    //    $("#imageView").prop('src', image);
    //} else {
    //    $("#imageView").prop('src', image);
    //}
    $("#imageView").prop('src', image);
}
