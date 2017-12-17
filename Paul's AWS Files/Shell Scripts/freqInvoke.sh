#!/bin/bash

cat Aclog.txt | tr ' ' ',' | tr '/' '-' | cut -d ',' -f1,2,4,7,10 | sed 's/#//' | sed -e '1i\Date,Time,X,Y,Z' > Aclog.csv
cat Amlog.txt | tr ' ' ',' | tr '/' '-' | cut -d ',' -f1,2,3 | sed 's/#//' | sed 's/PM//' | sed 's/AM//' | sed -e '1i\Date,Time,Ambient Light' > Amlog.csv
cat Balog.txt | tr ' ' ',' | tr '/' '-' | cut -d ',' -f1,2,3 | sed 's/#//' | sed 's/PM//' | sed 's/AM//' | sed -e '1i\Date,Time,Barometer Data' > Balog.csv
cat Colog.txt | tr ' ' ',' | tr '/' '-' | cut -d ',' -f1,2,4 | sed 's/#//' | sed -e '1i\Date,Time,Orientation' > Colog.csv
cat Gylog.txt | tr ' ' ',' | tr '/' '-' | cut -d ',' -f1,2,4,7,10 | sed 's/#//' | sed -e '1i\Date,Time,X,Y,Z' > Gylog.csv
cat Malog.txt | tr ' ' ',' | tr '/' '-' | cut -d ',' -f1,2,4,7,10 | sed 's/#//' | sed -e '1i\Date,Time,X,Y,Z' > Malog.csv
cat Pelog.txt | tr ' ' ',' | tr '/' '-' | cut -d ',' -f1,2,3 | sed 's/#//' | sed 's/PM//' | sed 's/AM//' | sed -e '1i\Date,Time,Steps' > Pelog.csv

python Aclog.py
python Amlog.py
python Balog.py
python Colog.py
python Gylog.py
python Malog.py
python Pelog.py
