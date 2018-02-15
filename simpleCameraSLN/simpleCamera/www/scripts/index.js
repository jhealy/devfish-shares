// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkID=397704
// To debug code on page load in cordova-simulate or on Android devices/emulators: launch your app, set breakpoints, 
// and then run "window.location.reload()" in the JavaScript Console.
(function () {
    "use strict";

    document.addEventListener( 'deviceready', onDeviceReady.bind( this ), false );

    function onDeviceReady() {
        // Handle the Cordova pause and resume events
        document.addEventListener( 'pause', onPause.bind( this ), false );
        document.addEventListener( 'resume', onResume.bind( this ), false );
        
        // TODO: Cordova has been loaded. Perform any initialization that requires Cordova here.
        document.getElementById( 'btnTakePhoto' ).onclick = function ()
        {
            // alert will not show in windows apps 
            // alert( 'takephotoonclick' );
            navigator.camera.getPicture(
                function ( imageUri )
                {
                    var lastPhotoContainer = document.getElementById( "lastPhoto" );
                    // alert will not show in windows apps 
                    alert( "looking good!" );
                    lastPhotoContainer.innerHTML = "<img src='" + imageUri + "' style='width:75%'/>";
                }, null, null );
        };

        document.getElementById( 'btnScan' ).onclick = function ()
        {
            // alert will not show in windows apps 
            // alert( "Scan was clicked" );
            cordova.plugins.barcodeScanner.scan(
                function ( result )
                {
                    alert( "We got a barcode\n" +
                        "Result: " + result.text + "\n" +
                        "Format: " + result.format + "\n" +
                        "Cancelled: " + result.cancelled );
                },
                function ( error )
                {
                    alert( "Scanning failed: " + error );
                },
                {
                    preferFrontCamera: true, // iOS and Android
                    showFlipCameraButton: true, // iOS and Android
                    showTorchButton: true, // iOS and Android
                    torchOn: true, // Android, launch with the torch switched on (if available)
                    saveHistory: true, // Android, save scan history (default false)
                    prompt: "Place a barcode inside the scan area", // Android
                    resultDisplayDuration: 500, // Android, display scanned text for X ms. 0 suppresses it entirely, default 1500
                    formats: "QR_CODE,PDF_417", // default: all but PDF_417 and RSS_EXPANDED
                    orientation: "landscape", // Android only (portrait|landscape), default unset so it rotates with the device
                    disableAnimations: true, // iOS
                    disableSuccessBeep: false // iOS and Android
                }
            );
        };
    };

    function onPause() {
        // TODO: This application has been suspended. Save application state here.
    };

    function onResume() {
        // TODO: This application has been reactivated. Restore application state here.
    };
} )();