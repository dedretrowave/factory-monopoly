mergeInto(LibraryManager.library, {
  SaveExtern: function(data) {
    var dataString = UTF8ToString(data);
    var playerData = JSON.parse(dataString);
    player.setData(playerData);
  },
  
  LoadExtern: function() {
    player.getData().then(data => {
        const json = JSON.stringify(data);
        myGameInstance.SendMessage("SaveSystem", "SetPlayerData", json);
    })
  }
});