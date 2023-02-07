mergeInto(LibraryManager.library, {
  SaveExtern: function(data) {
    // var dataString = UTF8ToString(data);
    // localStorage.setItem('player', dataString);
  },
  
  LoadExtern: function() {
    // SendMessage("SaveSystem", "SetPlayerData", localStorage.getItem('player') || '');
  },
  
  SubscribeForVisibilityChange: function() {
    document.addEventListener("visibilitychange", function() {
      SendMessage("AudioOnUnfocusSwitcher", "OnVisibilityChange", document.visibilityState);
    });
    
    if (document.visibilityState != "visible") {
      SendMessage("AudioOnUnfocusSwitcher", "OnVisibilityChange", document.visibilityState);
    }
  }
});