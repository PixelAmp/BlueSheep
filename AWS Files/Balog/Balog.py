#cat Balog.txt | tr ' ' ',' | tr '/' '-' | cut -d ',' -f1,2,3 | sed 's/#//' | sed 's/PM//' | sed 's/AM//' | sed -e '1i\Date,Time,Ambient Light' > Balog.csv
from matplotlib import pyplot, dates
from csv import reader
from dateutil import parser

with open('Balog.csv', 'r') as f:
    data = list(reader(f))

light = [i[2] for i in data[1::]]
time = [parser.parse(i[1]) for i in data[1::]]

pyplot.plot(time, light)
pyplot.title('Barometer Sensor Data over Time')
pyplot.xlabel('Time')
pyplot.ylabel('Pressure')
#pyplot.show()

pyplot.legend(['Pressure'], loc=4)

pyplot.savefig('Balog.png')
