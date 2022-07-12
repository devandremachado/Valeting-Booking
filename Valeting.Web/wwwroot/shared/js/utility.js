var Utility = (function () {

    $(document).ready(function () {
        Initialize();
    });

    function Initialize() {
        Animeted();
    }

    function Animeted() {
        $('.modal').on('show.bs.modal', function (event) {
            $('main').removeClass('fadeInDown');
        });
    }

    var ModalMessage = (function () {

        function Show(messageType, message, callback, allowExternalClick = true) {
            switch (messageType) {
                case 0:
                    Error(message, '', callback, allowExternalClick);
                    break;
                case 1:
                    Sucess(message, '', callback, allowExternalClick);
                    break;
                case 2: ;
                    Warning(message, '', callback, allowExternalClick);
                    break;
                default:
                    ModelSwalMensagem(message, '', null, callback, allowExternalClick);
            }
        }

        function ModelSwalMensagem(message, title, icon, callback, allowExternalClick = true) {
            Swal.fire({
                icon: icon,
                title: title,
                html: message,
                confirmButtonText: 'OK',
                allowEnterKey: false,
                allowOutsideClick: allowExternalClick
            }).then((result) => {
                if (result.value) {
                    if (callback) {
                        return callback();
                    }
                }
            });
        }

        function Sucess(message, title = 'Sucess!', callback, allowExternalClick = true) {
            if (!title)
                title = 'Sucess!';

            ModelSwalMensagem(message, title, 'success', callback, allowExternalClick);
        }

        function Error(message, title = 'Something went wrong... try again later', callback, allowExternalClick = true) {
            if (!title)
                title = 'Something went wrong... try again later';

            ModelSwalMensagem(message, title, 'error', callback, allowExternalClick);
        }

        function Warning(message, title = 'Oops...', callback, allowExternalClick = true) {
            if (!title)
                title = 'Oops...';

            ModelSwalMensagem(message, title, 'warning', callback, allowExternalClick);
        }

        function Information(message, title, callback, allowExternalClick = true) {

            ModelSwalMensagem(message, title, 'info', callback, allowExternalClick);
        }

        function RequestConformation({ message, title = 'Are you sure?', confirmationCallback } = {}) {
            Swal.fire({
                title: title,
                html: message,
                icon: 'warning',
                showCancelButton: true,
                cancelButtonText: 'Cancel',
                cancelButtonColor: '#d33',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Continue'
            }).then((result) => {
                if (result.value) {
                    if (confirmationCallback) {
                        return confirmationCallback();
                    }
                }
            })
        }

        return {
            Show: Show,
            Sucess: Sucess,
            Error: Error,
            Warning: Warning,
            Information: Information,
            RequestConformation: RequestConformation
        };
    })();

    function BlockUI(mensagem = '') {
        const loading = ResolveUrl("~/images/shared/loading.gif")

        $.blockUI({
            baseZ: 9999999999,
            fadeIn: 0,
            message: `<div><img src="${loading}" width="120" /><p>${mensagem}</p><\div>`,
            css: {
                border: 'none',
                padding: '15px',
                backgroundColor: 'none',
                '-webkit-border-radius': '10px',
                '-moz-border-radius': '10px',
                opacity: 1,
                color: '#ffffff'
            },

            overlayCSS: {
                backgroundColor: '#ffffff',
                opacity: 0.8,
                cursor: 'wait'
            }
        });
    }

    function UnblockUI() {
        $.unblockUI();
    }

    function ConfigureDataTable(IdTable, searching = false, lengthChange = false, msgZeroRecords = 'No record found') {
        $(IdTable).DataTable({
            "responsive": true,
            "paging": true,
            "lengthChange": lengthChange,
            "ordering": false,
            "info": false,
            "searching": searching,
            "lengthMenu": [[10, 20, 30, 40, 50, -1], [10, 20, 30, 40, 50, "All"]],
            "language": {
                "zeroRecords": msgZeroRecords,
            }
        });
    }

    function ResolveUrl(url) {
        if (url.indexOf("~/") == 0) {
            url = Master_Vars.baseUrl + url.substring(2);
        }
        return url;
    }

    function ClearDataTable(IdTable) {
        if ($.fn.DataTable.isDataTable(IdTable)) {
            $(IdTable).DataTable().destroy();
        }
        IdTable.find('tbody').empty();
    }

    function CamelCaseFormatWithSpaces(content) {
        const result = content.replace(/([A-Z])/g, " $1");
        return result.charAt(0).toUpperCase() + result.slice(1);
    }

    return {
        ModalMessage: ModalMessage,
        BlockUI: BlockUI,
        UnblockUI: UnblockUI,
        ConfigureDataTable: ConfigureDataTable,
        ClearDataTable: ClearDataTable,
        CamelCaseFormatWithSpaces: CamelCaseFormatWithSpaces
    };
})();