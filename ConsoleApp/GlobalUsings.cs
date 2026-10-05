//global - pozwala na uzyćie przestrzeni nazw w całym projekcie, bez konieczności dodawania dyrektywy using w każdym pliku.
//Dzięki temu można uniknąć powtarzania tych samych dyrektyw using w wielu plikach, co poprawia czytelność i organizację kodu.
//Globalne dyrektywy using są szczególnie przydatne, gdy korzystamy z wielu klas z tej samej przestrzeni nazw lub gdy chcemy mieć dostęp do często używanych klas bez konieczności importowania ich w każdym pliku.
//alternatywnie można globale skonfigurować w pliku projektu, dodając element <Using> do sekcji <ItemGroup>, co pozwala na jeszcze bardziej centralne zarządzanie globalnymi dyrektywami using. W ten sposób można zdefiniować globalne dyrektywy using dla całego projektu, co jest szczególnie przydatne w większych projektach, gdzie wiele plików korzysta z tych samych przestrzeni nazw.
global using System;

