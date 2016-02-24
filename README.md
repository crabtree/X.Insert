# X.Insert

Some classes that helps interacting with InsERT GT applications set (quite common ERP class system in Poland - so the rest of the README.md will be only in Polish)

---

`X.Insert` to zbiór klas ułatwiających interakcje z pakietem InsERT GT.

Projekt `X.Insert.DTO` zawiera zbiór klas reprezentujących obiekty biznesowe takie jak 
Kontrahent (`ContractorDTO`), Adres (`AddressDTO`), Towar (`ProductDTO`) itp.  

Serwisy zawarte w projekcie `X.Insert.Reader` pozwalają wykonywać na bazie danych systemu InsERT GT operacje tylko 
do odczytu. W żaden sposób nie modyfikują zawartości bazy danych. Nie wymagają do działania licencji Sfery. 
