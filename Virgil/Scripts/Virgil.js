/// <reference path="_references.js" />
$(document).ready(function() {
    //Dom loaded...
    $("#Languages").on("change", function () {
        var currentLingo = $("#Languages option:selected").val();
        switch (currentLingo) {
            case "English":
                //hide all divs but English
                $(".lingoEnglish").fadeIn("slow", function () {
                    $(".lingoEnglish").removeClass("hidden");
                });

                $(".lingoGerman").fadeOut("slow", function () {
                    $(".lingoGerman").addClass("hidden");
                });
                $(".lingoSpanish").fadeOut("slow", function () {
                    $(".lingoSpanish").addClass("hidden");
                });
                break;
            case "German":
                $(".lingoEnglish").fadeOut("slow", function () {
                    $(".lingoEnglish").addClass("hidden");
                });
                $(".lingoGerman").fadeIn("slow", function () {
                    $(".lingoGerman").removeClass("hidden");
                });
                $(".lingoSpanish").fadeOut("slow", function () {
                    $(".lingoSpanish").addClass("hidden");
                });
                break;
            case "Spanish":
                $(".lingoEnglish").fadeOut("slow", function () {
                    $(".lingoEnglish").addClass("hidden");
                });
                $(".lingoGerman").fadeOut("slow", function () {
                    $(".lingoGerman").addClass("hidden");
                });
                $(".lingoSpanish").fadeIn("slow", function () {
                    $(".lingoSpanish").removeClass("hidden");
                });
                break;
            default:
        }
    });


    $(".colorPicker").spectrum({
        preferredFormat: "hex",
        color: "green"
    });

	$("#addNewMedia").on("click", function(e) {
		e.preventDefault();
		$("#uploadMedia").modal("show");
	});

    tinymce.init({
        selector: "textarea",
        theme: "modern",
        plugins: [
            "advlist autolink link image lists charmap print preview hr anchor pagebreak spellchecker",
            "searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking",
            "save table contextmenu directionality emoticons template paste textcolor"
        ],
        content_css: "/Content/bootstrap.css,/Content/flatty.css",
        toolbar: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | l      ink image | print preview media fullpage | forecolor backcolor emoticons",
        style_formats: [
                { title: "Bold text", inline: "b" },
                { title: "Red text", inline: "span", styles: { color: "#ff0000" } },
                { title: "Red header", block: "h1" },
                { title: "Example 1", inline: "span", classes: "example1" },
                { title: "Example 2", inline: "span", classes: "example2" },
                { title: "Table styles" },
                { title: "Table row 1", selector: "tr", classes: "tablerow1" }
        ],
        verify_html: false
    });

    $(".hasTooltip").each(function() {
        $(this).qtip({
            content: {
                text: $(this).next("div"),
                title: "Topic Body Text"
            },
            style: {
                classes: "qtip-bootstrap qtip-shadow",
                width: 700
            },
            position: {
                my: "top right",
                at: "top left",
                target: $(this)
            }
        });
    });

    $('#topicsForSection').chosen({
        no_results_text: "Oops!  Topic not found!",
        width: "95%",
        placeholder_text_multiple: "Please add or remove topics..."
    });

    $('.assignTopic').on("click", function (e) {
        $("#pleaseWait").modal('show');
        e.preventDefault();
        var btn = this;
        $.ajax({
            type: "POST",
            async: true,
            url: "/Home/GetTopicsForSection/" + $(this).data('sectionid'),
            dataType: "json",
            complete: function (results) {
                $(".sectName").text($(btn).data('section'));
                $("#sectionId").val($(btn).data('sectionid'));
                $(".encounterName").text($(btn).data("encounter"));
                var items = results.responseJSON;
                $("#topicsForSection").find('option').remove().end();
                $.each(items, function (index, item) {
                    var selected = item.Selected ? "selected" : "";
                    $("#topicsForSection").append("<option " + selected  + " val='" + item.Value + "'>" + item.Text + "</option>");
                });
                $('#topicsForSection').trigger('chosen:updated');
                $("#pleaseWait").modal('hide').fadeOut('slow');
                $('#assignTopicsDialog').modal('show');
            }
        });
    });

    $("#btnSaveTopics").on("click", function(e) {
        e.preventDefault();
        var topics = {
            sectionId: $('#sectionId').val(),
            topics: $('#topicsForSection').chosen().val()
        };

        $.ajax({
            type: "POST",
            async: false,
            url: "/Home/UpdateTopicsForSection/",
            dataType: "json",
            data: topics,
            complete: function (result) {
                window.location.reload();
            }
        });
    })
});
