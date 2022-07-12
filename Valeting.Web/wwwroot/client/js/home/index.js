var Home = (function () {
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
        txtEmailFocusOutEvent();
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

            CreateBooking();
        });
    }

    function txtEmailFocusOutEvent() {
        fields.txtEmail.on('focusout', function () {
            if (!fields.txtEmail.valid())
                return;

            GetCustomerByEmail();
        });
    }

    function CreateBooking() {
        const data = {
            'Customer': {
                'Name': fields.txtName.val(),
                'Email': fields.txtEmail.val(),
                'Phone': fields.txtPhone.val(),
            },
            'BookingDate': fields.txtDtBooking.val(),
            'Flexibility': fields.cmbFlexibility.val(),
            'VehicleSize': fields.cmbVehicleSize.val()
        };

        Utility.BlockUI();

        return new Promise((resolve, reject) => {
            $.ajax({
                url: Booking_Actions.CreateBooking,
                type: 'POST',
                dataType: 'json',
                async: true,
                data: data,
                success: function (data) {
                    if (data.isSucces)
                        Utility.ModalMessage.Sucess(`${fields.txtName.val()}\n your booking has been successfully made!`);
                    else
                        Utility.ModalMessage.Error(`${fields.txtName.val()}\n It was not possible to make your booking. Try again later.`);
                },
                error: function (erro) {
                    Utility.ModalMessage.Error();
                    console.log(erro);
                    reject(erro);
                },
                complete: function () {
                    Utility.UnblockUI();
                }
            });
        });
    }

    function GetCustomerByEmail() {
        const data = {
            'email': fields.txtEmail.val(),
        };

        Utility.BlockUI();
        return new Promise((resolve, reject) => {
            $.ajax({
                type: 'GET',
                url: Booking_Actions.GetCustomerByEmail,
                dataType: 'json',
                data: data,
                contentType: 'application/json',
                success: function (data) {

                    if (data.isSucces) {
                        fields.txtName.val(data.result.name)
                        fields.txtPhone.val(data.result.phone)
                    }
                    resolve();
                },
                error: function (erro) {
                    Utility.ModalMessage.Error('');
                    console.log(erro);
                    reject(erro);
                },
                complete: function () {
                    Utility.UnblockUI();
                }
            });
        });
    }
})();