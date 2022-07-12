var CarBooking = (function () {
    const boxHome = $('#Cadastro');
    const formRegistration = boxHome.find('#formCadastro');

    const fields = {
        txtName: boxHome.find('#txtName'),
        txtDtBooking: boxHome.find('#txtDtBooking'),
        cmbFlexibility: boxHome.find('#cmbFlexibility'),
        cmbVehicleSize: boxHome.find('#cmbVehicleSize'),
        txtPhone: boxHome.find('#txtPhone'),
        txtEmail: boxHome.find('#txtEmail'),

        BtnSave: boxHome.find('#btnSalvar')
    };

    $(document).ready(async function () {
        Initialize();
        btnSaveClickEvent();
    });

    function Initialize() {
        InitializePlugins();
        ValidFields();
    }

    function InitializePlugins() {
        fields.txtDtBooking.datepicker({});
    }

    function ValidFields() {

        validator = boxHome.find('#formCadastro').validate({
            rules: {
                txtName: {
                    required: true,
                    normalizer: function (value) {
                        return $.trim(value);
                    }
                },
                txtDtBooking: {
                    required: true,
                    normalizer: function (value) {
                        return $.trim(value);
                    }
                },
                cmbFlexibility: {
                    required: true,
                    normalizer: function (value) {
                        return $.trim(value);
                    }
                },
                cmbVehicleSize: {
                    required: true,
                    normalizer: function (value) {
                        return $.trim(value);
                    }
                },
                txtPhone: {
                    required: true,
                    normalizer: function (value) {
                        return $.trim(value);
                    }
                },
                txtEmail: {
                    required: true,
                    normalizer: function (value) {
                        return $.trim(value);
                    },
                    email: true
                }
            },
            errorPlacement: function (error, element) {
                error.insertAfter(element);
            }
        });
    }

    function btnSaveClickEvent() {
        fields.BtnSave.on('click', function () {
            if (!formRegistration.valid()) {
                Utility.ModalMessage.Warning('There are inconsistencies. Please review the data.');
                return;
            }

            Utility.ModalMessage.Information('Not implemented...');
        });
    }
})();