//---------------------------------------------------------------------------
// This script is based on the work of Dieter Bungers - http://www.infovation.de
// The original example for the "Cross Browser Expanding and Collapsing TOC"
// was published on http://www.siteexperts.com/tips/techniques/ts03/index.htm
//---------------------------------------------------------------------------

var tocTab = new Array();var ir=0;
tocTab[ir++] = new Array ("1", "Introducci&oacute;n", "introducción2.htm", "", "cicon1.gif", "cicon2.gif");
tocTab[ir++] = new Array ("1.1", "Caracteristicas Generales", "caracteristicasgenerales.htm", "", "cicon1.gif", "cicon2.gif");
tocTab[ir++] = new Array ("1.1.1", "Introducci&oacute;n", "introducción.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("1.1.2", "Proyectos", "proyecto.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("1.1.3", "Tablas", "tablas1.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("1.1.4", "Atributos", "atributos.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("1.1.5", "Hechos", "hechos.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("1.1.6", "Filtros", "filtros.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("1.1.7", "Metricas", "metricas.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("1.1.8", "Reportes", "reportes.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("1.2", "Caracteristicas T&eacute;cnicas", "caracteristicastécnicas.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("2", "Instalaci&oacute;n", "instalación.htm", "", "cicon1.gif", "cicon2.gif");
tocTab[ir++] = new Array ("3", "Seguridad", "seguridad.htm", "", "cicon1.gif", "cicon2.gif");
tocTab[ir++] = new Array ("3.1", "Perfiles de usuarios", "perfilesdeusuarios2.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("3.2", "Cambio de usuario", "caracteristicastécnicas3.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("4", "Comenzando a utilizar BIC", "comenzandoautilizarbic.htm", "", "cicon1.gif", "cicon2.gif");
tocTab[ir++] = new Array ("4.1", "Generalidades", "generalidades.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("4.2", "Inicio sesi&oacute;n", "iniciosesión.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("4.3", "Proyectos", "proyecto2.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("4.4", "Tablas", "tablas12.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("4.5", "Atributos", "atributos2.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("4.6", "Hechos", "hechos2.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("4.7", "Filtros", "filtros2.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("4.8", "Metricas", "metricas2.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("4.9", "Reportes", "reportes2.htm", "", "cicon1.gif", "cicon2.gif");
tocTab[ir++] = new Array ("4.9.1", "Configuraci&oacute;n de reporte", "configuracióndereporte.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("4.9.2", "Visualizaci&oacute;n de reportes", "visualizacióndereportes.htm", "", "cicon9.gif", "cicon9.gif");
tocTab[ir++] = new Array ("5", "Ayuda", "ayuda.htm", "", "cicon1.gif", "cicon2.gif");
isContent = true,
isIndex = false,
showNumbers = false,
textSizes = new Array(1, 1, 0.7, 0.7),
tocBehaviour = new Array(1,1),
tocScroll=false,
tocLinks = new Array(1,0);
var isIE = navigator.appName.toLowerCase().indexOf("explorer") > -1;
var mdi = (isIE) ? textSizes[1]:textSizes[3];
var sml = (isIE) ? textSizes[2]:textSizes[4];
var oldCurrentNumber = "", oldLastVisitNumber = "";
var toDisplay = new Array();
for (ir=0; ir<tocTab.length; ir++) {
toDisplay[ir] = tocTab[ir][0].split(".").length==1;
}
function reDisplay(currentNumber,tocChange,noLink,e) {
if (isIndex && (toc.location.href.substring(toc.location.href.lastIndexOf("/")+1,toc.location.href.length) != "bicmariano_kwindex.htm")) { isIndex=false; isContent=true; }
if (currentNumber == "navIndex") { isContent=false; }
if (currentNumber == "navContent") { isIndex=false; isContent=true; }
if (e) {
ctrlKeyDown = (isIE) ? e.ctrlKey : (e.modifiers==2);
if (tocChange && ctrlKeyDown) tocChange = 2;
}
var currentNumArray = currentNumber.split(".");
var currentLevel = currentNumArray.length-1;
var currentIndex = 0;
var scrollY=0, addScroll=tocScroll;
if (currentNumber == "") currentNumber = top.location.href.substring(top.location.href.lastIndexOf("?")+1,top.location.href.length);
for (i=0; i<tocTab.length; i++) {
if ((tocTab[i][0] == currentNumber) || (tocTab[i][2] == currentNumber && tocTab[i][2] != "")) {
currentIndex = i;
currentNumber = tocTab[i][0];
currentNumArray = currentNumber.split(".");
currentLevel = currentNumArray.length-1;
break;
}
}
if (currentIndex < tocTab.length-1) {
nextLevel = tocTab[currentIndex+1][0].split(".").length-1;
currentIsExpanded = nextLevel > currentLevel && toDisplay[currentIndex+1];
}
else currentIsExpanded = false;
theHref = (noLink) ? "" : tocTab[currentIndex][2];
theTarget = tocTab[currentIndex][3];
for (i=1; i<tocTab.length; i++) {
if (tocChange) {
thisNumber = tocTab[i][0];
thisNumArray = thisNumber.split(".");
thisLevel = thisNumArray.length-1;
isOnPath = true;
if (thisLevel > 0) {
for (j=0; j<thisLevel; j++) {
isOnPath = (j>currentLevel) ? false : isOnPath && (thisNumArray[j] == currentNumArray[j]);
}
}
toDisplay[i] = (tocChange == 1) ? isOnPath : (isOnPath || toDisplay[i]);
if (thisNumber.indexOf(currentNumber+".")==0 && thisLevel > currentLevel) {
if (currentIsExpanded) toDisplay[i] = false;
else toDisplay[i] = (thisLevel == currentLevel+1);
}
}
}
if (!isContent && !isIndex) {
toc.location.href = "bicmariano_kwindex.htm";
isIndex = true;
}
if (isContent) {
toc.document.write("<html>\n\r<head></head>\n\r<style type=\"text/css\">\n\r       SPAN.heading1 { font-family: Arial,Helvetica; font-weight: normal; font-size: 10pt; color: #000000; text-decoration: none }\n\r       SPAN.heading2 { font-family: Arial,Helvetica; font-weight: normal; font-size: 9pt; color: #000000; text-decoration: none }\n\r       SPAN.heading3 { font-family: Arial,Helvetica; font-weight: normal; font-size: 8pt; color: #000000; text-decoration: none }\n\r       SPAN.heading4 { font-family: Arial,Helvetica; font-weight: normal; font-size: 8pt; color: #000000; text-decoration: none }\n\r       SPAN.heading5 { font-family: Arial,Helvetica; font-weight: normal; font-size: 8pt; color: #000000; text-decoration: none }\n\r       SPAN.heading6 { font-family: Arial,Helvetica; font-weight: normal; font-size: 8pt; color: #000000; text-decoration: none }\n\r\n\r       SPAN.hilight1 { font-family: Arial,Helvetica; font-weight: normal; font-size: 10pt; color: #FFFFFF; background: #002682; text-decoration: none }\n\r       SPAN.hilight2 { font-family: Arial,Helvetica; font-weight: normal; font-size: 9pt; color: #FFFFFF; background: #002682; text-decoration: none }\n\r       SPAN.hilight3 { font-family: Arial,Helvetica; font-weight: normal; font-size: 8pt; color: #FFFFFF; background: #002682; text-decoration: none }\n\r       SPAN.hilight4 { font-family: Arial,Helvetica; font-weight: normal; font-size: 8pt; color: #FFFFFF; background: #002682; text-decoration: none }\n\r       SPAN.hilight5 { font-family: Arial,Helvetica; font-weight: normal; font-size: 8pt; color: #FFFFFF; background: #002682; text-decoration: none }\n\r       SPAN.hilight6 { font-family: Arial,Helvetica; font-weight: normal; font-size: 8pt; color: #FFFFFF; background: #002682; text-decoration: none }\n\r</style>\n\r<body bgcolor=\"#FFFFFF\">\n\r<font face=\"Arial,Helvetica\" size=\"4\"><b>Manual de Usuario</b></font><br><br>\n\r\n\r  <!-- Place holder for the TOC, do not delete the line below -->\n\r  ");}
for (i=0; i<tocTab.length; i++) {
if (toDisplay[i]) {
thisNumber = tocTab[i][0];
thisNumArray = thisNumber.split(".");
thisLevel = thisNumArray.length-1;
isCurrent = (i == currentIndex);
if (i < tocTab.length-1) {
nextLevel = tocTab[i+1][0].split(".").length-1;
img = (thisLevel >= nextLevel) ? tocTab[i][4] : ((toDisplay[i+1]) ? tocTab[i][5] : tocTab[i][4]);
}
else img = tocTab[i][4];
if (isContent) {
thisTextClass = ((thisNumber==currentNumber)?("hilight"):("heading"));
if (addScroll) scrollY+=((thisLevel<2)?mdi:sml)*25;
if (isCurrent) addScroll=false;
toc.document.write("<table border=0 cellspacing=0 cellpadding=2>");
toc.document.write("<tr><td width=" + ((thisLevel+1) * 20) + " align=right valign=top>");
toc.document.write("<a href=\"javaScript:history.go(0)\" onMouseDown=\"parent.reDisplay('" + thisNumber + "'," + tocBehaviour[0] + "," + tocLinks[0] + ",event)\">");
toc.document.write("<img src=\"" + img + "\" border=0></a>");
toc.document.write("</td><td align=left>");
toc.document.write("<a href=\"javaScript:history.go(0)\" onMouseDown=\"parent.reDisplay('" + thisNumber + "'," + tocBehaviour[1] + "," + tocLinks[1] + ",event)\">");
toc.document.write("<span class=\""  + thisTextClass + ((thisLevel>5) ? 6 : thisLevel+1) + "\">");
toc.document.write( ((showNumbers)?(thisNumber+" "):"") + tocTab[i][1]);
toc.document.write("</span></a>");
toc.document.writeln("</td></tr></table>");
} //isContent
}
}
if (!noLink) {
oldLastVisitNumber = oldCurrentNumber;
oldCurrentNumber = currentNumber;
}
if (isContent) {
toc.document.write("\n\r\n\r<hr><font face=\"Arial,Helvetica\" size=\"1\">Business Intelligence Client - 2007</font>\n\r</body>\n\r</html>\n\r");
toc.document.close();
if (tocScroll) toc.scroll(0,scrollY);
}
if (theHref)
if (theTarget=="top") top.location.href = theHref;
else if (theTarget=="parent") parent.location.href = theHref;
else if (theTarget=="blank") open(theHref,"");
else content.location.href = theHref;
}
