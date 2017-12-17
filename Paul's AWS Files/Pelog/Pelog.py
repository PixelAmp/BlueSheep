#Pelog.txt | tr ' ' ',' | tr '/' '-' | cut -d ',' -f1,2,3 | sed 's/#//' | sed 's/PM//' | sed 's/AM//' | sed -e '1i\Date,Time,Steps' > Pelog.csv
import numpy as np
import matplotlib.pyplot as plt
from csv import reader
from dateutil import parser

with open('Pelog.csv', 'r') as f:
    data = list(reader(f))

compass = [i[2] for i in data[1::]]
time = [parser.parse(i[1]) for i in data[1::]]

plt.plot(time, compass)
plt.title('Steps over Time')
plt.xlabel('Time')
plt.ylabel('Steps')

plt.legend(['Steps'], loc=4)
plt.savefig('Pelog.png')
