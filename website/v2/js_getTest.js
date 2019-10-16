//Passing values from html forms by Id, Test. -DC  
function getName() {
      var nTest = document.getElementById("NAME").value;
      document.getElementById("UNIT_STORY").value = nTest;
      alert(nTest);
  }
