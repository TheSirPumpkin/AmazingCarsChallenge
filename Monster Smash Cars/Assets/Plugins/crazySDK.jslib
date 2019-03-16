mergeInto(LibraryManager.library, {

  Init: function (version, objectName) {
    Crazygames.init({
      version: Pointer_stringify(version),
      crazySDKObjectName: Pointer_stringify(objectName),
      sdkType: "unity5.6",
    });
  },

  RequestAd: function (adType) {
    Crazygames.requestAd(Pointer_stringify(adType));
  },
});
