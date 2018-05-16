
# GeekoutOut 2018 (17-18.05.2018)

Repozytorium zawiera przykłady omawiane podczas prezentacji.

### Konfiguracja środowiska

Przykłady wykorzystujące biblioteki enova365 wymagają ustawienia dwóch parametrów w pliku ***MSBuild\common.soneta.assembly.props*** 
 - ExtensionOtput - ścieżka zawierająca dodatki ładowane przez enova365
 - SonetaBinaries - binaria enova365
 
 Przykład ***GeekOut2018.EnovaExtension.Tests*** zawiera referencję do bibliteki ***Soneta.Test***, która daje możliwość pisania testów integracyjnych w enova365. Biblioteka ta nie jest jeszcze oficjalnie dostępna, jednak dla celów demonstracyjnych podpięliśmy ją do projektu. Aby uruchomić ten przykład z konkretną wersją aplikacji enova365, należy zmodyfikować wersję bibliotek 
 - Soneta.Business
 - Soneta.Types
 - Soneta.Start

w pliku ***GeekOut2018.EnovaExtension.Tests\App.config***. Biblioteka ***Soneta.Test*** skompilowana została z zależnościami, które widoczne są w atrybucie oldVersion, natomiast konkretną wersję ustawiamy w atrybucie newVersion.
