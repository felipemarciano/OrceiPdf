


function resetForm(form) {
    // clearing inputs
    var inputs = form.getElementsByTagName('input');
    for (var i = 0; i < inputs.length; i++) {
        switch (inputs[i].type) {
            // case 'hidden':
            case 'text':
            case 'hidden':
                inputs[i].value = '';
                break;
            case 'radio':
            case 'checkbox':
                inputs[i].checked = false;
        }
    }

    form.getElementsByTagName('input')["Codigo"].value = '00000000-0000-0000-0000-000000000000';

    // clearing selects
    var selects = form.getElementsByTagName('select');
    for (var i = 0; i < selects.length; i++)
        selects[i].selectedIndex = 0;

    // clearing textarea
    var text = form.getElementsByTagName('textarea');
    for (var i = 0; i < text.length; i++)
        text[i].innerHTML = '';

    return false;
}

function boolToText(value) {
    if (value) {
        return "Ativo";
    } else {
        return "Inativo";
    }
}

function checkBoxClick(e) {
    $(e).val(!($(e).val() == 'true'));
}

function radioBoxClick(e) {
    e.prop("checked", true);
}