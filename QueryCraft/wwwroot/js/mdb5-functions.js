async function initializeMdbInputs() {
    const { Input } = await import("../lib/MDB5/js/mdb.es.min.js");
    const elements = document.querySelectorAll("[data-mdb-input-init]:not([data-mdb-input-initialized])");
    elements.forEach((element) => { new Input(element).init() });
}

async function initializeMdbAlerts() {
    const { Alert } = await import("../lib/MDB5/js/mdb.es.min.js");
    const elements = document.querySelectorAll("[data-mdb-alert-init]:not([data-mdb-alert-initialized]), [data-mdb-toast-init]:not([data-mdb-toast-initialized])");
    elements.forEach((element) => { Alert.getOrCreateInstance(element) });
}

async function initializeMdbSelects() {
    const { Select } = await import("../lib/MDB5/js/mdb.es.min.js");
    const elements = document.querySelectorAll("[data-mdb-select-init]:not([data-mdb-select-initialized])");
    elements.forEach((element) => { Select.getOrCreateInstance(element) });
}

async function initializeMdbCollapses() {
    const { Collapse } = await import("../lib/MDB5/js/mdb.es.min.js");
    const elements = document.querySelectorAll("[data-mdb-collapse-init]:not([data-mdb-collapse-initialized]), .accordion");
    elements.forEach((element) => { Collapse.getOrCreateInstance(element) });
}

async function getOrCreateMdbModal(id) {
    const { Modal } = await import("../lib/MDB5/js/mdb.es.min.js");
    const element = document.getElementById(id);
    return Modal.getOrCreateInstance(element);
}

async function getOrCreateMdbAnimation(id) {
    const { Animation } = await import("../lib/MDB5/js/mdb.es.min.js");
    const element = document.getElementById(id);
    return Animation.getOrCreateInstance(element);
}

async function getOrCreateMdbSelect(id) {
    const { Select } = await import("../lib/MDB5/js/mdb.es.min.js");
    const element = document.getElementById(id);
    return Select.getOrCreateInstance(element);
}

async function getOrCreateMdbCollapse(id) {
    const { Collapse } = await import("../lib/MDB5/js/mdb.es.min.js");
    const element = document.getElementById(id);
    return Collapse.getOrCreateInstance(element);
}

async function showMdbCollapse(id) {
    const collapse = await getOrCreateMdbCollapse(id);
    if (collapse) { collapse.show(); }
}

async function hideMdbCollapse(id) {
    const collapse = await getOrCreateMdbCollapse(id);
    if (collapse) { collapse.hide(); }
}

function collapseAll() {
    var collapseElements = document.querySelectorAll("[data-custom-collapsible-content]");
    var anyShown = Array.from(collapseElements).some(element => element.classList.contains("collapse") && element.classList.contains("show"));
    if (anyShown) { collapseElements.forEach(element => hideMdbCollapse(element.id)); }
    else { collapseElements.forEach(element => showMdbCollapse(element.id)); }
}

async function showMdbModal(id) {
    const modal = await getOrCreateMdbModal(id);
    if (modal) { modal.show(); }
}

async function hideMdbModal(id) {
    const modal = await getOrCreateMdbModal(id);
    if (modal) { modal.hide(); }
}

async function stopMdbAnimation(id) {
    const animate = await getOrCreateMdbAnimation(id);
    if (animate) { animate.stopAnimation(); }
}

async function getMdbSelectValue(id) {
    const instance = await getOrCreateMdbSelect(id);
    if (instance) { return document.getElementById(id).value };
}

async function setMdbSelectValue(id, value) {
    const instance = await getOrCreateMdbSelect(id);
    const select = document.getElementById(id);

    if (instance) {
        if (instance.multiple) {
            instance.setValue(value.map(String));
        } else {
            const optionsToDeselect = select.querySelectorAll(`option[selected], option[selected="selected"]`);
            optionsToDeselect.forEach(option => option.removeAttribute("selected"));

            instance.setValue(`${value}`);
        }
    }
}

async function destroyMdbSelect(id) {
    const instance = await getOrCreateMdbSelect(id);
    const select = document.getElementById(id);
    if (instance) instance.dispose();
    select.options = [];
    select.innerHTML = "";
}

async function updateMdbSelect(id, options = []) {
    await destroyMdbSelect(id);
    const select = document.getElementById(id);
    options.forEach((option) => { select.add(option) });
    await getOrCreateMdbSelect(id);
}

async function showMdbToast(color, headerContent, bodyContent) {
    const { Toast } = await import("../lib/MDB5/js/mdb.es.min.js");
    const toast = document.createElement('div');
    var icon;
    switch (color) {
        case "success":
            icon = "check-circle";
            break;
        case "danger":
            icon = "times-circle"
            break;
        case "warning":
            icon = "exclamation-circle"
            break;
        default:
            icon = "bell";
            break;
    }
    toast.classList.add('toast', 'fade');
    toast.innerHTML = `<div class="toast-header fw-bold"><i class="fas fa-${icon} me-2"></i>${headerContent}</div><div class="toast-body">${bodyContent}</div>`;
    document.body.appendChild(toast);

    const toastInstance = new Toast(toast, {
        color: color,
        stacking: true,
        hidden: true,
        width: '350px',
        position: 'top-right',
        autohide: true,
        delay: 4000,
    });
    toastInstance.show();
}