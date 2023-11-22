# JV2A_Dumaine_Lisa_Shooter

Différents types de tir

modifier le score : faire en sorte qu'en killant 1 ennemis, ça augmente le score
(petits ennemis : 1 points; Ennemis for : 3 points; Ennemis trefor : 5 points)


Spawn d'ennemis :
-creer un empti vide "ennemisCreation"
-creer un script qui, toutes les x secondes, fait spawn un ennemis (parmis les 3 prefab disponibles), à une certaines coordonnée

requis :
-créer 8 emplacements de spawn d'ennemis
-faire un random.randint(1,11) : 1 : pas d'ennemis; entre 2 et 5 : petit ennemis; entre 6 et 9 : ennemis for; 10 : ennermis trefor;
-si score élevé, baisser le taux de spawn des petits ?

Truc bonus :
-le script fait spawn 3 lignes d'ennemis.
-chaque ligne se stop a un endroit précis;
-quand les 3 rangées d'ennemis sont détruites, en refait spawn 3