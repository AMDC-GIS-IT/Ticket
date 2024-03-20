(function (root, factory) {
	if (typeof define === 'function' && define.amd) {
		// AMD. Register as an anonymous module.
		define(['exports', 'echarts'], factory);
	} else if (typeof exports === 'object' && typeof exports.nodename !== 'string') {
		// CommonJS
		factory(exports, require('echarts'));
	} else {
		// Browser globals
		factory({}, root.echarts);
	}
}(this, function (exports, echarts) {
	var log = function (msg) {
		if (typeof console !== 'undefined') {
			console && console.error && console.error(msg);
		}
	}
	if (!echarts) {
		log('ECharts is not Loaded');
		return;
	}
	if (!echarts.registerMap) {
		log('ECharts Map is not loaded')
		return;
	}
	echarts.registerMap('countries/nr/nr-all',
{
    "type": "FeatureCollection",
    "features": [
        {
            "type": "Feature",
            "properties": {
                "id": "AT",
                "featurecla": "Admin-1 scale rank",
                "scalerank": 5,
                "adm1_code": "NRU-4978",
                "diss_me": 4978,
                "iso_3166_2": "NR-03",
                "wikipedia": "http://en.wikipedia.org/wiki/Anetan_District",
                "iso_a2": "NR",
                "adm0_sr": 3,
                "name": "Anetan",
                "name_alt": "",
                "name_local": "",
                "type_en": "",
                "code_local": "",
                "note": "",
                "hasc_maybe": "",
                "postal": "",
                "sameascity": -99,
                "woe_name": "Anetan",
                "latitude": -0.494702,
                "longitude": 166.936,
                "admin": "Nauru",
                "gn_a1_code": "03",
                "min_zoom": 9
            },
            "geometry": {
                "type": "Polygon",
                "coordinates": [
                    [
                        [
                            166.93123184787086,
                            -0.49331800203003046
                        ],
                        [
                            166.9388461346678,
                            -0.4904110659999219
                        ],
                        [
                            166.93897303944775,
                            -0.5041529454149806
                        ],
                        [
                            166.93123184787086,
                            -0.49331800203003046
                        ]
                    ]
                ]
            }
        },
        {
            "type": "Feature",
            "properties": {
                "id": "EW",
                "featurecla": "Admin-1 scale rank",
                "scalerank": 5,
                "adm1_code": "NRU-4977",
                "diss_me": 4977,
                "iso_3166_2": "NR-09",
                "wikipedia": "http://en.wikipedia.org/wiki/Ewa_District",
                "iso_a2": "NR",
                "adm0_sr": 3,
                "name": "Ewa",
                "name_alt": "",
                "name_local": "",
                "type_en": "",
                "code_local": "",
                "note": "",
                "hasc_maybe": "",
                "postal": "",
                "sameascity": -99,
                "woe_name": "Ewa",
                "latitude": -0.502076,
                "longitude": 166.934,
                "admin": "Nauru",
                "gn_a1_code": "09",
                "min_zoom": 9
            },
            "geometry": {
                "type": "Polygon",
                "coordinates": [
                    [
                        [
                            166.9251404184333,
                            -0.4956964042364829
                        ],
                        [
                            166.93123184787086,
                            -0.49331800203003046
                        ],
                        [
                            166.93897303944775,
                            -0.5041529454149806
                        ],
                        [
                            166.9380847059881,
                            -0.5104953512988538
                        ],
                        [
                            166.9251404184333,
                            -0.4956964042364829
                        ]
                    ]
                ]
            }
        },
        {
            "type": "Feature",
            "properties": {
                "id": "BA",
                "featurecla": "Admin-1 scale rank",
                "scalerank": 5,
                "adm1_code": "NRU-4976",
                "diss_me": 4976,
                "iso_3166_2": "NR-05",
                "wikipedia": "http://en.wikipedia.org/wiki/Baiti_District",
                "iso_a2": "NR",
                "adm0_sr": 3,
                "name": "Baiti",
                "name_alt": "",
                "name_local": "",
                "type_en": "",
                "code_local": "",
                "note": "",
                "hasc_maybe": "",
                "postal": "",
                "sameascity": -99,
                "woe_name": "Baiti",
                "latitude": -0.500672,
                "longitude": 166.925,
                "admin": "Nauru",
                "gn_a1_code": "05",
                "min_zoom": 9
            },
            "geometry": {
                "type": "Polygon",
                "coordinates": [
                    [
                        [
                            166.91803375075614,
                            -0.49833907335476346
                        ],
                        [
                            166.9251404184333,
                            -0.4956964042364829
                        ],
                        [
                            166.9380847059881,
                            -0.5104953512988538
                        ],
                        [
                            166.93757708686832,
                            -0.5136665542407904
                        ],
                        [
                            166.93719637252846,
                            -0.516573490270899
                        ],
                        [
                            166.91803375075614,
                            -0.49833907335476346
                        ]
                    ]
                ]
            }
        },
        {
            "type": "Feature",
            "properties": {
                "id": "UA",
                "featurecla": "Admin-1 scale rank",
                "scalerank": 5,
                "adm1_code": "NRU-4975",
                "diss_me": 4975,
                "iso_3166_2": "NR-13",
                "wikipedia": "http://en.wikipedia.org/wiki/Uaboe_District",
                "iso_a2": "NR",
                "adm0_sr": 3,
                "name": "Uaboe",
                "name_alt": "",
                "name_local": "",
                "type_en": "",
                "code_local": "",
                "note": "",
                "hasc_maybe": "",
                "postal": "",
                "sameascity": -99,
                "woe_name": "Uaboe",
                "latitude": -0.506992,
                "longitude": 166.924,
                "admin": "Nauru",
                "gn_a1_code": "13",
                "min_zoom": 9
            },
            "geometry": {
                "type": "Polygon",
                "coordinates": [
                    [
                        [
                            166.91346517867797,
                            -0.5001889417375598
                        ],
                        [
                            166.91803375075614,
                            -0.49833907335476346
                        ],
                        [
                            166.93719637252846,
                            -0.516573490270899
                        ],
                        [
                            166.9368156581886,
                            -0.5201410935805777
                        ],
                        [
                            166.91346517867797,
                            -0.5001889417375598
                        ]
                    ]
                ]
            }
        },
        {
            "type": "Feature",
            "properties": {
                "id": "NI",
                "featurecla": "Admin-1 scale rank",
                "scalerank": 5,
                "adm1_code": "NRU-4974",
                "diss_me": 4974,
                "iso_3166_2": "NR-12",
                "wikipedia": "http://en.wikipedia.org/wiki/Nibok_District",
                "iso_a2": "NR",
                "adm0_sr": 3,
                "name": "Nibok",
                "name_alt": "",
                "name_local": "",
                "type_en": "",
                "code_local": "",
                "note": "",
                "hasc_maybe": "",
                "postal": "",
                "sameascity": -99,
                "woe_name": "Nibok",
                "latitude": -0.512961,
                "longitude": 166.921,
                "admin": "Nauru",
                "gn_a1_code": "13",
                "min_zoom": 9
            },
            "geometry": {
                "type": "Polygon",
                "coordinates": [
                    [
                        [
                            166.91029255917923,
                            -0.5120809527698221
                        ],
                        [
                            166.91346517867797,
                            -0.5001889417375598
                        ],
                        [
                            166.9368156581886,
                            -0.5201410935805777
                        ],
                        [
                            166.9365618486287,
                            -0.5223873623311162
                        ],
                        [
                            166.93618113428886,
                            -0.5251621649053108
                        ],
                        [
                            166.92843994271198,
                            -0.5227837626988583
                        ],
                        [
                            166.9203180367952,
                            -0.5206696274042338
                        ],
                        [
                            166.91029255917923,
                            -0.5120809527698221
                        ]
                    ]
                ]
            }
        },
        {
            "type": "Feature",
            "properties": {
                "id": "DE",
                "featurecla": "Admin-1 scale rank",
                "scalerank": 5,
                "adm1_code": "NRU-4973",
                "diss_me": 4973,
                "iso_3166_2": "NR-08",
                "wikipedia": "http://en.wikipedia.org/wiki/Denigomodu_District",
                "iso_a2": "NR",
                "adm0_sr": 3,
                "name": "Denigomodu",
                "name_alt": "",
                "name_local": "",
                "type_en": "",
                "code_local": "",
                "note": "",
                "hasc_maybe": "",
                "postal": "",
                "sameascity": -99,
                "woe_name": "Denigomodu",
                "latitude": -0.520335,
                "longitude": 166.914,
                "admin": "Nauru",
                "gn_a1_code": "08",
                "min_zoom": 9
            },
            "geometry": {
                "type": "Polygon",
                "coordinates": [
                    [
                        [
                            166.90699303490055,
                            -0.5248978979934826
                        ],
                        [
                            166.91029255917923,
                            -0.5120809527698221
                        ],
                        [
                            166.9203180367952,
                            -0.5206696274042338
                        ],
                        [
                            166.9168916077366,
                            -0.5242372307139125
                        ],
                        [
                            166.90699303490055,
                            -0.5248978979934826
                        ]
                    ]
                ]
            }
        },
        {
            "type": "Feature",
            "properties": {
                "id": "AI",
                "featurecla": "Admin-1 scale rank",
                "scalerank": 5,
                "adm1_code": "NRU-4972",
                "diss_me": 4972,
                "iso_3166_2": "NR-01",
                "wikipedia": "http://en.wikipedia.org/wiki/Aiwo_District",
                "iso_a2": "NR",
                "adm0_sr": 3,
                "name": "Aiwo",
                "name_alt": "",
                "name_local": "",
                "type_en": "",
                "code_local": "",
                "note": "",
                "hasc_maybe": "",
                "postal": "",
                "sameascity": -99,
                "woe_name": "Aiwo",
                "latitude": -0.529816,
                "longitude": 166.913,
                "admin": "Nauru",
                "gn_a1_code": "01",
                "min_zoom": 9
            },
            "geometry": {
                "type": "Polygon",
                "coordinates": [
                    [
                        [
                            166.91194232131858,
                            -0.536922042481659
                        ],
                        [
                            166.90699303490055,
                            -0.5248978979934826
                        ],
                        [
                            166.9168916077366,
                            -0.5242372307139125
                        ],
                        [
                            166.9161301790569,
                            -0.5291261685827315
                        ],
                        [
                            166.91790684597618,
                            -0.5350721740988627
                        ],
                        [
                            166.91194232131858,
                            -0.536922042481659
                        ]
                    ]
                ]
            }
        },
        {
            "type": "Feature",
            "properties": {
                "id": "BO",
                "featurecla": "Admin-1 scale rank",
                "scalerank": 5,
                "adm1_code": "NRU-4971",
                "diss_me": 4971,
                "iso_3166_2": "NR-06",
                "wikipedia": "http://en.wikipedia.org/wiki/Boe_District",
                "iso_a2": "NR",
                "adm0_sr": 3,
                "name": "Boe",
                "name_alt": "",
                "name_local": "",
                "type_en": "",
                "code_local": "",
                "note": "",
                "hasc_maybe": "",
                "postal": "",
                "sameascity": -99,
                "woe_name": "Boe",
                "latitude": -0.538594,
                "longitude": 166.916,
                "admin": "Nauru",
                "gn_a1_code": "06",
                "min_zoom": 9
            },
            "geometry": {
                "type": "Polygon",
                "coordinates": [
                    [
                        [
                            166.9163839886168,
                            -0.5474927189547811
                        ],
                        [
                            166.91194232131858,
                            -0.536922042481659
                        ],
                        [
                            166.91790684597618,
                            -0.5350721740988627
                        ],
                        [
                            166.92006422723532,
                            -0.5387719108644554
                        ],
                        [
                            166.91828756031603,
                            -0.5403575123354237
                        ],
                        [
                            166.9163839886168,
                            -0.5474927189547811
                        ]
                    ]
                ]
            }
        },
        {
            "type": "Feature",
            "properties": {
                "id": "YA",
                "featurecla": "Admin-1 scale rank",
                "scalerank": 5,
                "adm1_code": "NRU-4983",
                "diss_me": 4983,
                "iso_3166_2": "NR-14",
                "wikipedia": "http://en.wikipedia.org/wiki/Yaren_District",
                "iso_a2": "NR",
                "adm0_sr": 3,
                "name": "Yaren",
                "name_alt": "",
                "name_local": "",
                "type_en": "",
                "code_local": "",
                "note": "",
                "hasc_maybe": "",
                "postal": "",
                "sameascity": -99,
                "woe_name": "Yaren",
                "latitude": -0.543159,
                "longitude": 166.925,
                "admin": "Nauru",
                "gn_a1_code": "14",
                "min_zoom": 9
            },
            "geometry": {
                "type": "Polygon",
                "coordinates": [
                    [
                        [
                            166.9326278004503,
                            -0.5506639218967178
                        ],
                        [
                            166.9163839886168,
                            -0.5474927189547811
                        ],
                        [
                            166.91828756031603,
                            -0.5403575123354237
                        ],
                        [
                            166.92006422723532,
                            -0.5387719108644554
                        ],
                        [
                            166.92526732321323,
                            -0.5344115068192925
                        ],
                        [
                            166.9326278004503,
                            -0.5506639218967178
                        ]
                    ]
                ]
            }
        },
        {
            "type": "Feature",
            "properties": {
                "id": "ME",
                "featurecla": "Admin-1 scale rank",
                "scalerank": 5,
                "adm1_code": "NRU-4982",
                "diss_me": 4982,
                "iso_3166_2": "NR-11",
                "wikipedia": "http://en.wikipedia.org/wiki/Meneng_District",
                "iso_a2": "NR",
                "adm0_sr": 3,
                "name": "Meneng",
                "name_alt": "",
                "name_local": "",
                "type_en": "",
                "code_local": "",
                "note": "",
                "hasc_maybe": "",
                "postal": "",
                "sameascity": -99,
                "woe_name": "Meneng",
                "latitude": -0.539648,
                "longitude": 166.939,
                "admin": "Nauru",
                "gn_a1_code": "04",
                "min_zoom": 9
            },
            "geometry": {
                "type": "Polygon",
                "coordinates": [
                    [
                        [
                            166.95318637480207,
                            -0.5333544391719803
                        ],
                        [
                            166.95128280310283,
                            -0.5391683112321974
                        ],
                        [
                            166.9388461346678,
                            -0.5518531229999439
                        ],
                        [
                            166.9326278004503,
                            -0.5506639218967178
                        ],
                        [
                            166.92526732321323,
                            -0.5344115068192925
                        ],
                        [
                            166.93541970560918,
                            -0.5297868358623016
                        ],
                        [
                            166.9453182784452,
                            -0.5322973715246682
                        ],
                        [
                            166.95318637480207,
                            -0.5333544391719803
                        ]
                    ]
                ]
            }
        },
        {
            "type": "Feature",
            "properties": {
                "id": "AR",
                "featurecla": "Admin-1 scale rank",
                "scalerank": 5,
                "adm1_code": "NRU-4981",
                "diss_me": 4981,
                "iso_3166_2": "NR-04",
                "wikipedia": "http://en.wikipedia.org/wiki/Anibare_District",
                "iso_a2": "NR",
                "adm0_sr": 3,
                "name": "Anibare",
                "name_alt": "",
                "name_local": "",
                "type_en": "",
                "code_local": "",
                "note": "",
                "hasc_maybe": "",
                "postal": "",
                "sameascity": -99,
                "woe_name": "Anibare",
                "latitude": -0.519984,
                "longitude": 166.947,
                "admin": "Nauru",
                "gn_a1_code": "04",
                "min_zoom": 9
            },
            "geometry": {
                "type": "Polygon",
                "coordinates": [
                    [
                        [
                            166.9573742325404,
                            -0.511288152034338
                        ],
                        [
                            166.95826256600003,
                            -0.5176305579182112
                        ],
                        [
                            166.95318637480207,
                            -0.5333544391719803
                        ],
                        [
                            166.9453182784452,
                            -0.5322973715246682
                        ],
                        [
                            166.93541970560918,
                            -0.5297868358623016
                        ],
                        [
                            166.93618113428886,
                            -0.5251621649053108
                        ],
                        [
                            166.9365618486287,
                            -0.5223873623311162
                        ],
                        [
                            166.9368156581886,
                            -0.5201410935805777
                        ],
                        [
                            166.93719637252846,
                            -0.516573490270899
                        ],
                        [
                            166.93757708686832,
                            -0.5136665542407904
                        ],
                        [
                            166.9380847059881,
                            -0.5104953512988538
                        ],
                        [
                            166.93897303944775,
                            -0.5041529454149806
                        ],
                        [
                            166.94671423102466,
                            -0.5087776163719715
                        ],
                        [
                            166.9573742325404,
                            -0.511288152034338
                        ]
                    ]
                ]
            }
        },
        {
            "type": "Feature",
            "properties": {
                "id": "IJ",
                "featurecla": "Admin-1 scale rank",
                "scalerank": 5,
                "adm1_code": "NRU-4980",
                "diss_me": 4980,
                "iso_3166_2": "NR-10",
                "wikipedia": "http://en.wikipedia.org/wiki/Ijuw_District",
                "iso_a2": "NR",
                "adm0_sr": 3,
                "name": "Ijuw",
                "name_alt": "",
                "name_local": "",
                "type_en": "",
                "code_local": "",
                "note": "",
                "hasc_maybe": "",
                "postal": "",
                "sameascity": -99,
                "woe_name": "Ijuw",
                "latitude": -0.504534,
                "longitude": 166.951,
                "admin": "Nauru",
                "gn_a1_code": "10",
                "min_zoom": 9
            },
            "geometry": {
                "type": "Polygon",
                "coordinates": [
                    [
                        [
                            166.9555975656211,
                            -0.4979426729870214
                        ],
                        [
                            166.9573742325404,
                            -0.511288152034338
                        ],
                        [
                            166.94671423102466,
                            -0.5087776163719715
                        ],
                        [
                            166.93897303944775,
                            -0.5041529454149806
                        ],
                        [
                            166.9555975656211,
                            -0.4979426729870214
                        ]
                    ]
                ]
            }
        },
        {
            "type": "Feature",
            "properties": {
                "id": "AB",
                "featurecla": "Admin-1 scale rank",
                "scalerank": 5,
                "adm1_code": "NRU-4979",
                "diss_me": 4979,
                "iso_3166_2": "NR-02",
                "wikipedia": "http://en.wikipedia.org/wiki/Anabar_District",
                "iso_a2": "NR",
                "adm0_sr": 3,
                "name": "Anabar",
                "name_alt": "",
                "name_local": "",
                "type_en": "",
                "code_local": "",
                "note": "",
                "hasc_maybe": "",
                "postal": "",
                "sameascity": -99,
                "woe_name": "Anabar",
                "latitude": -0.497511,
                "longitude": 166.944,
                "admin": "Nauru",
                "gn_a1_code": "02",
                "min_zoom": 9
            },
            "geometry": {
                "type": "Polygon",
                "coordinates": [
                    [
                        [
                            166.9388461346678,
                            -0.4904110659999219
                        ],
                        [
                            166.9555975656211,
                            -0.4979426729870214
                        ],
                        [
                            166.93897303944775,
                            -0.5041529454149806
                        ],
                        [
                            166.9388461346678,
                            -0.4904110659999219
                        ]
                    ]
                ]
            }
        },
        {
            "type": "Feature",
            "properties": {
                "id": "BU",
                "featurecla": "Admin-1 scale rank",
                "scalerank": 5,
                "adm1_code": "NRU-4970",
                "diss_me": 4970,
                "iso_3166_2": "NR-07",
                "wikipedia": "http://en.wikipedia.org/wiki/Buada_District",
                "iso_a2": "NR",
                "adm0_sr": 3,
                "name": "Buada",
                "name_alt": "",
                "name_local": "",
                "type_en": "",
                "code_local": "",
                "note": "",
                "hasc_maybe": "",
                "postal": "",
                "sameascity": -99,
                "woe_name": "Buada",
                "latitude": -0.527877,
                "longitude": 166.925,
                "admin": "Nauru",
                "gn_a1_code": "07",
                "min_zoom": 9
            },
            "geometry": {
                "type": "Polygon",
                "coordinates": [
                    [
                        [
                            166.93618113428886,
                            -0.5251621649053108
                        ],
                        [
                            166.93541970560918,
                            -0.5297868358623016
                        ],
                        [
                            166.92526732321323,
                            -0.5344115068192925
                        ],
                        [
                            166.92006422723532,
                            -0.5387719108644554
                        ],
                        [
                            166.91790684597618,
                            -0.5350721740988627
                        ],
                        [
                            166.9161301790569,
                            -0.5291261685827315
                        ],
                        [
                            166.9168916077366,
                            -0.5242372307139125
                        ],
                        [
                            166.9203180367952,
                            -0.5206696274042338
                        ],
                        [
                            166.92843994271198,
                            -0.5227837626988583
                        ],
                        [
                            166.93618113428886,
                            -0.5251621649053108
                        ]
                    ]
                ]
            }
        }
    ]
})
}));