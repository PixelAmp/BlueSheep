#cat Amlog.txt | tr ' ' ',' | tr '/' '-' | cut -d ',' -f1,2,3 | sed 's/#//' | sed 's/PM//' | sed 's/AM//' | sed -e '1i\Date,Time,Ambient Light' > Amlog.csv
from matplotlib import pyplot, dates
from csv import reader
from dateutil import parser

with open('Amlog.csv', 'r') as f:
    data = list(reader(f))

light = [i[2] for i in data[1::]]
time = [parser.parse(i[1]) for i in data[1::]]

pyplot.plot(time, light)
pyplot.title('Ambient Sensor Data over Time')
pyplot.xlabel('Time')
pyplot.ylabel('Light')
#pyplot.show()

pyplot.legend(['Light'], loc=4)

pyplot.savefig('Amlog.png')
