mergeInto(LibraryManager.library, {
  SaveExtern: function(data) {
    var dataString = UTF8ToString(data);
    var playerData = JSON.parse(dataString);
    player.setData(playerData);
  },
  
  LoadExtern: function() {
    player.getData().then(_data => {
        const json = JSON.stringify(_data);
        myGameInstance.SendMessage("SaveSystem", "SetPlayerData", json);
    })
  },
});