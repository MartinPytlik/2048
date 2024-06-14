#2048-Project
Tento projekt je replika hry 2048, vytvořená pomocí C# a WPF.

##Popis
Při spuštění programu se zobrazí úvodní okno, ve kterém je možnost ukončit program nebo začít hru.

##Ovládání
Hra se ovládá šipkami a při zmáčknutí klávesy Enter se skóre a herní pole vynulují. Skóre je součet nově spojených čísel. Cílem hry je dosáhnout čísla 2048 a zároveň nasbírat co nejvyšší skóre.

##Konec hry
Pokud dojdou možné tahy, hra se ukončí a zobrazí se okno Game Over, ve kterém je vidět celkové skóre a také nejvyšší dosažené číslo. V tomto okně jsou možnosti ukončit program nebo začít hru znovu.

Data uchovávám v dvojrozměrném poli s názvem Herní pole, ve kterém nula znamená, že tam žádná hodnota není, a každá jiní hodnota se ukazoju, tak je tak je.
Následně používám tři funkce pro generování náhodnych dat do pole, VygenerujZacatek(), VygenerujSouradnice(). Funkce Zobraz pole, vezme hodnoty z dvojrozměrného HerníhoPole a propíše je do xaml gridu. Metoda OnKeyDown sleduje, jestli se stiskla klávesa a následně zavolá příslušnou funkci. Pohyb zajišťuje čtveřice metod
