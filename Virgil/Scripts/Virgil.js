﻿/// <reference path="_references.js" />
$(document).ready(function() {
    //Dom loaded...
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
        content_css: "css/content.css",
        toolbar: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | l      ink image | print preview media fullpage | forecolor backcolor emoticons",
        style_formats: [
                { title: "Bold text", inline: "b" },
                { title: "Red text", inline: "span", styles: { color: "#ff0000" } },
                { title: "Red header", block: "h1", styles: { color: "#ff0000" } },
                { title: "Example 1", inline: "span", classes: "example1" },
                { title: "Example 2", inline: "span", classes: "example2" },
                { title: "Table styles" },
                { title: "Table row 1", selector: "tr", classes: "tablerow1" }
        ]
    });

    $(".hasTooltip").each(function() {
        $(this).qtip({
            content: {
                text: $(this).next("div"),
                title: "Topic Body Text"
            },
            style: {
                classes: "qtip-bootstrap qtip-shadow"
            },
            position: {
                my: "bottom right",
                at: "top left",
                target: $(this)
            }
        });
    });
});