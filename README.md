#2048-Project
Tento projekt je replika hry 2048, vytvořená pomocí C# a WPF.

##Popis
Při spuštění programu se zobrazí úvodní okno, ve kterém je možnost ukončit program nebo začít hru.

##Ovládání
Hra se ovládá šipkami a při zmáčknutí klávesy Enter se skóre a herní pole vynulují. Skóre je součet nově spojených čísel. Cílem hry je dosáhnout čísla 2048 a zároveň nasbírat co nejvyšší skóre.

##Konec hry
Pokud dojdou možné tahy, hra se ukončí a zobrazí se okno Game Over, ve kterém je vidět celkové skóre a také nejvyšší dosažené číslo. V tomto okně jsou možnosti ukončit program nebo začít hru znovu.

Data uchovávám v dvojrozměrném poli s názvem HerníPole, ve kterém nula znamená, že tam žádná hodnota není, a každá jiná hodnota se zobrazí tak, jak je.
Následně používám tři funkce pro generování náhodných dat do pole: VygenerujZacatek(), Vygeneruj(), VygenerujSouradnice(). Funkce ZobrazPole() vezme hodnoty z dvojrozměrného pole HerníPole a propíše je do XAML gridu. Metoda OnKeyDown() sleduje, zda byla stisknuta klávesa, a následně zavolá příslušnou funkci.
Pohyb zajišťuje čtveřice metod MoveLeft(), MoveRight(), MoveUp(), MoveDown(). Ke každé z těchto metod patří metoda CanMove, která rozhodne, zda je pohyb tímto směrem možný. Skóre je zobrazováno pomocí metody ScoreDisplay() a přičítáno pomocí PrictiBody().
Konec hry posuzuje trojice metod:
DoslaPole() zkontroluje, zda je možný nějaký pohyb a zda jsou volná pole.
GameOver2() změní XAML na GameOver.
Vyhra() změní proměnnou na true, aby se v GameOver oknu zobrazilo "Vyhráli jste".
Metoda JeVPoli2048() prochází pole a kontroluje, zda se v poli nachází číslo 2048. Metoda Vybarvy() mění barvu textových polí na základě jejich hodnot.

