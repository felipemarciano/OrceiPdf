
//jquery blockUI
$.blockUI.defaults = {
    message: "Carregando...",
    overlayCSS: {
        backgroundColor: '#000',
        opacity: 0.4,
        cursor: 'wait',
        display: 'block',
    },
    css: {
        width: '30%',
        top: '40%',
        left: '35%',
        textAlign: 'center',
        cursor: 'wait',
        border: 'none',
        padding: '15px',
        backgroundColor: '#000',
        '-webkit-border-radius': '10px',
        '-moz-border-radius': '10px',
        opacity: .5,
        color: '#fff',
    },
    baseZ: 5000,
    fadeIn: 200,
    fadeOut: 600,
};

$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);

//Jquery DataTable
$.extend(true, $.fn.dataTable.defaults, {
    dom: "<'row'<'col-sm-6'B><'col-sm-6'f>>" +
        "<'row'<'col-sm-12'l'>>" +
        "<'row'<'col-sm-12'tr>>" +
        "<'row'<'col-sm-5'i><'col-sm-7'p>>",
    buttons: [
        { extend: 'copy', text: 'Copiar' },
        { extend: 'csvHtml5', text: 'CSV', fieldSeparator: ';', bom: true, charSet: "utf-8" },
        { extend: 'excel', text: 'EXCEL' },
        { extend: 'pdf', text: 'PDF' },
        { extend: 'print', text: 'Imprimir' }
    ],
    destroy: true,
    autoWidth: false,
    processing: true,
    serverSide: true,
    stateSave: true,
    searchDelay: 600,
    "language": {
        "url": "//cdn.datatables.net/plug-ins/1.10.19/i18n/Portuguese-Brasil.json"
    },
    responsive: {
        details: {
            type: 'column'
        }
    },
    responsive: true
});

$.fn.dataTable.ext.legacy.ajax = true;

//***************


//Jquery Validate + Bootstrap 4
jQuery.validator.setDefaults({
    highlight: function (element) {
        jQuery(element).closest('.form-control').addClass('is-invalid');
    },
    unhighlight: function (element) {
        jQuery(element).closest('.form-control').removeClass('is-invalid');
    },
    errorElement: 'div',
    errorClass: 'invalid-feedback',
    errorPlacement: function (error, element) {
        if (element.parent('.input-group').length) {
            error.insertAfter(element.parent());
        }
        else if ($(element).hasClass("select2-hidden-accessible") || $(element).hasClass("custom-control-input")) {
            $($(element).next()).after(error);
        } else {
            error.insertAfter(element);
        }

    },
    submitHandler: function (form) {
        $.blockUI();
        form.submit();
    }
});

$.fn.select2.defaults.set("theme", "bootstrap");
$.fn.select2.defaults.set('language', 'pt-BR');


