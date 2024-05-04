var clickHamburguer = document.getElementById("div-func-hamburguer");
var ShowHamburguer = document.getElementById("menu-nav");

function show_func_hamburguer() {
  if (ShowHamburguer.style.display === "none") {
    ShowHamburguer.style.display = "block";
  } else {
    ShowHamburguer.style.display = "none";
  }
}
