// Attend que le contenu du DOM soit entièrement chargé avant d'exécuter le code
document.addEventListener("DOMContentLoaded", function() {
  
  // Sélectionne l'élément du DOM avec la classe "menu-site" et le stocke dans la variable menuSite
  const menuSite = document.querySelector(".menu-site");

  // Sélectionne l'élément du DOM avec la classe "nav-links" et le stocke dans la variable navLinks
  const navLinks = document.querySelector(".nav-links");

  // Ajoute un écouteur d'événements au clic sur l'élément avec la classe "menu-site"
  menuSite.addEventListener('click', () => {
    // Bascule la classe 'mobile-menu' de l'élément avec la classe "nav-links" lors du clic
    navLinks.classList.toggle('mobile-menu');
  });

  // Sélectionne l'élément du DOM avec l'ID "preloader" et le stocke dans la variable loader
  var loader = document.getElementById("preloader");

  // Ajoute un écouteur d'événements pour détecter le chargement complet de la page
  window.addEventListener("load", function(){
    // Une fois que la page est entièrement chargée, masque l'élément avec l'ID "preloader"
    loader.style.display = "none";
  })

});
