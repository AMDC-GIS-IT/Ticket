(function(root, factory) {
	if (typeof define === 'function' && define.amd) {
		define(['exports', 'echarts'], factory);
	} else if (typeof exports === 'object' && typeof exports.nodeName !== 'string') {
		factory(exports, require('echarts'));
	} else {
		factory({}, root.echarts);
	}
}(this, function(exports, echarts) {
	var log = function(msg) {
		if (typeof console !== 'undefined') {
			console && console.error && console.error(msg);
		}
	};
	
	if (!echarts) {
		log('ECharts is not Loaded');
		return;
	}
	if (!echarts.registerMap) {
		log('ECharts Map is not loaded');
		return;
	}
	echarts.registerMap('countries/nz/nz-all', {
		"type": "FeatureCollection",
		"features": [{
			"type": "Feature",
			"properties": {
				"name": "Auckland"
			},
			
			"geometry": {
				"type": "MultiPolygon",
				"coordinates": [
					["@@DRREAUUGBR"],
					["@@PAPIXANOKKLKCQiQuCW\\OLDVRVpJ"],
					["@@HLTJJKeI"],
					["@@KPnM[UET"],
					["@@DIMMDOMKULKCMbST@JbVITDNX@NFXGUcDYPK"],
					["@@[FPTIJQEoDJN^XMBIKMJOOILHJUNQ@EUaUATHRQRTDGXdFLGCOPI\\R^GJLTCPShCfJDLINFL^BHIZJTCL`TPRQTE^@NUS]YLYIWMHMCMNK@iCGWKBOYKBTOJaYGRBNQNc]QF"],
					["@@TDHLA\\no@WOC@__KS@M`GFDZNL"],
					["@@MVZDdOdFANMXj@WNHXSCM^c\\UEE\\NHXQTHvDCXWNS\\F\\G`VE^HDTTHPCLHhSDEUO@QH[\\NLMEWJMMOBWaGGGFMNCPNLITJJQfIRMRAPMRFREMUBOSBMqRIUQCMF]biTCNHPYLAV[NE@KPUWMIgMQSFaFeNMBHZ\\ABRMVg@COMESNKCWDFfKLJTPNGLYAMOiLFPGTOFFY]B_RANURG@mTUCBT"],
					["@@MIAMYHWRMTfAXEPLBY"],
					["@@YUSEEXZPZK"],
					["@@RHR@h\\NDEXVXhPVCPZRANTGTFLZDPP@VVHj}`_FSpyn]vMNMXAPDTCZMOWg]BMJSaBCZUM]@N]E]NYPMJTIFKTL\\JFB]NUTCNF\\WVKXGJFX@REgSUDuAGIQJSQgEMPa]MLGZLPS@IIEcN@RKO]HWN@JQX@RMCYDMKIKWEaU@GNNFLVGVMAOJBTOLBN]LmZAMPA^eDQ_WLKVPD]aFSSlC@KTGJcI]KFMITKBKU@J[KQODI[Ti[@CIjBVWlY^EXBLRCNLH`DRH^@PP^AJMG]oDKLEaQIMNeGGSOKOFUQUHONYlYD@I\\IX_JSD_HKTTHMJeVSSMDOIKPYGGX_JUEIRQAYHI\\SPWPGAYSGUBWLRHFPaXMFW_@OWF[AWG]@ITOPKTBVWDOZNRTBIR]c]DsANIZ@NKIOTAXFVEE_OC]FAi`QAMKYCWHSAM`ODJOJJJlWNvHNlFBL\\L\\AdIJDbMC]XDVQNLULGLXPKVPXENQCSJOc_B[WKIMVUFMRLUHBXVJL\\jVHRMTBZ`qTG\\SFIRCFMAUPCB]XISfZPFEbFQRFVKJ`NVCpDnKRgPGXJFOMEASHMEQDOQSLGNTTNHIVALTXC^RBMNQVGVHRRVNZS\\EXKFKbC@KJS^S^KHKEKLQCKFQoG»CIKeIQZ]XQKHMC]DEOMAWDKIWDOAUPuA_MCBOImSMAGSG_R³AEKaABMSGMDKOaU_`CLSE]@eQLOISDO[IKJuBKKYO[@WRwNO@_KAI[AQMWGeaKAUVYGSBs]_KBU[pÄs°UbKXE`BPTPTAPHV@RGZD\\GdZXOdBT[I]SEHMGOXeHW@UKMzYPCAKQMJ[@ORBJqZQK_PI^HORQlKNTRON@\\WTjL\\QLWJFnJXAANUBOGcHURGEuB[^XF\\@pP`ZT^PPNBZCJIZVZD\\PLXRNNKX@DOV@^THSC[HGNDJa\\VSPO@OCELPZ\\NIRU@@R]OEIaPMGMBIpM@sfWPAQ[CqKHPkVOBELJVNJTAHHGP_KYHBPnC`GDNeTAPRDTAbDRS`LFMVTATA]LSAEKIQFGLWIODSE]S[iOLCUWQIPOE@_[G@[H_]ZgJMLOkqWM@[U_OYHOPGlCCRQ`NHAVU`KDJPUPHTUnOFHXEdITAZShGF_r¾¾ÅÒYhEVHdNVRERLVHScLS\\vPB`RH@dsLALOLalqBa^YN]VJZIHLXIAKt_AM_QBSKCWeNUTHBQVAJPZFNAHWL@\\YLJP@A^RKLiFdP[PJPpFQHM`MBCVFJD`Y`IVTJ@TUFARJPbPCJ\\NSF@^QZFRNDE\\MAQ^JP[@EZO@KUJSNAAQLSMEWHDQ_CVOCUaLESMCKPebaNOROMPQYEaHGIcPMNPZNDNPALF`MLB`ZLdGTUHQNFJNdQHH`BTRlBFXXLN^VIHVTF\\Xj@JZGRPV"],
					["@@KBUTJLZOAQ"],
					["@@GIShBVN@BYHCBU"],
					["@@|eAWFUSUKNME_COCGZQBBTfE`DKL[AcNX^dF"],
					["@@EbFRdPTAPNTDPCVSIQDaEaQOmDcRQ@@T"]
				],
				"encodeOffsets": [
					[
						[179143, -37599]
					],
					[
						[179060, -37645]
					],
					[
						[179355, -37799]
					],
					[
						[179142, -37695]
					],
					[
						[179410, -37759]
					],
					[
						[179280, -37719]
					],
					[
						[179100, -37634]
					],
					[
						[179522, -37080]
					],
					[
						[179550, -37046]
					],
					[
						[179726, -36990]
					],
					[
						[178669, -37097]
					],
					[
						[179094, -37487]
					],
					[
						[178434, -37269]
					],
					[
						[179045, -37270]
					],
					[
						[179252, -37080]
					]
				]
			}
		},
		{
			"type": "Feature",
			"properties": {
				"name": "Bay of Plenty"
			},
			
			"geometry": {
				"type": "MultiPolygon",
				"coordinates": [
					["@@BRXGPMOCYH"],
					["@@Kf\\RhDTAJMQUJGKKDIWMmV"],
					["@@EOHWEIVcx^_KCSHC\\aBg_CQTICOYUVCXL\\ERUDOWCkYiCAO\\F^UDOcGBI[UPIXDN]dTXGSUWGJQRHREI]XGHcPFAPTPPD@_nFCWRYB[PGDRKLLJNIXNXKPABUtIPP[@VZXAtOISUAEIZULNHXDbP@Ia@YIQB[WGEQdFbZM]XCPHFPNDbEX^aPKLMKAK_OQTALPDPKPL@TUE]\\HdK^Q@CLPLFO~ml[jYe°ga_@ITOpLPLLTTWSib@PH^Km¤u]cÂknKfGªKUlIM~SaJKNTLEBSJKtU|M¼SHMqFiNUAmD@MQ[VFPC\\F@aNJAR\\CHQUINMVJJKP]dINFORMDGTP^ZIJLEb|IJI^NªA\\C\\D°H¤JvLRRX@HPRAVNTKLzRdNb`ENP\\`LbXBvhDBRPNCTNDNI`J\\X@NIJPT^LRT@NQTARxTNJ@LTNNb@PTL^F\\ElFLKZRCL^RrKjP^RTVBLLFH^RJJQhGdDRJDNTJAPfTV^QPIX@XNC`ShBZJpFREdDHQRTYËDSMIMGIc^]F[AQFMEWFKKOEONW[UA]^QHMx}čç±ŗ±ŉWBÛ¨d_hqBSPSAOIVgV[HQMIIaDMPMGUYK_EAWOMEcDKWI]FSS_AF_kMUBaWHIu@@QaHUCUMGaSCRSBUOYDkmį£ğjçEI[FESW[kT_YUmWQEIUUYLK@WK_eGOA]MLQCOTOEUQ[DWQOUIUAQGOUQ]cMAWQO@GNcD_EKPK@cRKV]F_YMPWAWMWUkVWAYEOI@WQQ[EC_Q@ILWCSDYK]HIOKDKISAWPKEUHMOUaAGLDPKNW@M\\WDQEUD_CaWM`QR_XSD{@YiJQKSF]YMDMIe_CaWA]eQviyjgO_SAOJ]AeT]F_`MZ[LSAW\\YrFRINM@XEèČłæĎ^hZXVJFPCjBNpàL~ITmDAJLPC\\QT@JWFeYM@]H]\\cZ@F_XSZAPUBGV]TIV_R[JQIEMoYUDIdM@I\\SEGZqOa]ªg@O\\M@hMAKPNNNAAiTNZIJmZWV]NJB`KLMCSVQxLN~RePk^NZ]VSEHZQNE^NH{^l¬ªDXOF@PSDING`KRYLUpOXNNBNeAVLBFNXLJTMTE\\U@GLDNRNETf\\V_^UZDz@CNahQGUXd`HLRGf\\HJMRCZZBH`IPLJNCXF"],
					["@@GLRLNCWS"],
					["@@AHBfNB@lpYAS]eW@EG"],
					["@@TMFSSESFEVTL"],
					["@@lIZ[n{v}tuVS VUSMq`KZcHKXaHEMPOMQMEMZcNGCWPKVB^THNIX@VQLHKN[JMPUTMFYVO\\_bSLA`FR"],
					["@@NQMQO@WZRPVE"]
				],
				"encodeOffsets": [
					[
						[181210, -38765]
					],
					[
						[180468, -38192]
					],
					[
						[180164, -38270]
					],
					[
						[180291, -38552]
					],
					[
						[180642, -38550]
					],
					[
						[180340, -38523]
					],
					[
						[180210, -38373]
					],
					[
						[181441, -38413]
					]
				]
			}
		},
		{
			"type": "Feature",
			"properties": {
				"name": "Canterbury"
			},
			
			"geometry": {
				"type": "MultiPolygon",
				"coordinates": [
					["@@JQFqCULn@ORB`I"],
					["@@jFPX^PHTXENvLRVJVBT\\XNXBZJ@Zb\\ZPjGPNENNTZRV`BNETTIR^\\OPHLtJNRbPCXINNRCL\\RfFVLjZDTPXOZJ^KJLXvP`CL`XD@LVL^A`PHXbXDJdV`FXCXnVXA@KXETKP`VRVPHRPpJBRVTHRlN^CNJVZz[^JXEEOXGVHVCD^hbCH^JRJBTWNn^TRDFZUXVH\\DlGVB~f\\I^JDRPN|DVRKPVZCJhTHJZNFTbTPFXEGaHGJ\\NVhRFNfxVSZHVx^KNJLPBHT`BDITIRXBZ\\JVANIRRfHPTNAPQ\\RRDHlRFNNETNNGFCVHHZBP\\^LLJ^NV@IPZVjJRMbZTCZMVDEWhJ^`VAHLMR`X`KfTNTdKFQNGPPRDAPLbHTEzGrLZVt]HOTLLNbPh\\YTFHGPHLdDPPBRQTPdDTXB\\PlODN\\DLNR@P^^TXDRTCLF^`PNLPb@LZVALZDfT^BD\\NPGXJVBxPTANFHVJHIZTZjhJLVFZAldJTCXLVRNrXVVJdJ@\\JXEZJ^TNXALfF`VJTTP\\nKZX^LLXMTL`XJBbZVLVAR@HPN`CZHDNZRHNXH\\dTJ\\ATFndDNIRC\\DRbdZRSTD\\LNfFjVFAL_HEVLhCEWNOBYMEDiPM`EHGJJJZCGK@Q\\UXNXADKEQOKAiFGBgxIJCFUgoJelSlPJGZLNAPaGGBaJGhAKiFKx_TEZHXAAMQGOaAYO@E_TEbANLP@fU@ONMGWhG\\NPX@R`APFLV\\EpARDZNFfJZZN^XJEZLTVBQR@JVLF\\CFHA\\TDdTVD`\\VLtfLPMPPFRGlHHJFZPIHQ`NBXL@RNPIZFfT\\IJVRJ^F@bjBGLMlCdIPBTPAXTGP`jfRz@CRRPDN`XVLZ@NLRfZK`Br\\CTlXfDhXMVBTTRJZ`Vn[nLNXNTXjDXAR~PTKPBXPX@^[RBCOvB`OXRJG\\LX_ASSQAIykQS@Ic[kkgm]sUqGcBOZe@WUO]Gy]OOEWSG[UGO_WiOCSeSgIg_BSC_WQ{_YWQ[IeFcVQTBHKRGoQifYBaCqKyQScYE[OOAQOUYUgQKQT[]Y]iOcme¯M[kIcKC[a]S[]UaB]TM_WEIukeQY_@[}ioGMcFMFWCYeYkIiOYASKwM[Bueg_oASMsyQYm[uMGG]]IJGLWIYM{GDeF·N^bKBK\\KDKVKICSIMUA@O@JQfAJKZE@SZ@PFRQcKcCiBaUYCUHIK_L[C_WSCBSKGNKNNLKOGLaRCTbRURHVTRX@NpGJSLBB`jLLMRPdFVJX@AQQiEebDHPGJT^BTPXxKGKFO\\TNENOBOUa@UW]LC@SR@@RXbLfPL@JNRLOTA@OZLDM`PNO^GO_`LU_XBZ`REXSQQGFQOILIZALNNDZKLOGKFSTIAKkGAKDJUAeMUUDKKLM@[]IAIVKUOLKeIC[MEOTOWSEa_UGIKgK{BBVUPQ@UZD^JJAbhXHPg@CbdCDLYLPJCNcADNQLQA_WLGQY\\GHYM[[IDeTeKKRORW\\IP]eI]NqFMKcFSNoCQH@LiPELqBi^SGQ\\WVODgBËEE÷UËI±MÁWwMÓsOqOÁi³i»qaµqÃy½qį£]ekcU£ocïµYS_]mqBOIObIC]HSQYJI@UGGyu¡OwE[AmLDFu@kH³CMYIMQEaNgFcJeAMJgASHiFcCqZKC[HKCaH[AIJSE_HUCODOG]H@Y}Fû@]AGEi@FMUM[RkOG]KETaiSGKQJOEa@EUU@QI]G[UISUGCWIIcQOWaBUOMYUKO@[KcEWFIR@PWLKd[`F\\IfNN`VAXJPOZaEJbGfSHiB_OEQUJeMiFSYaG]BUIqEUGKDFMMSBaNSZ_HZVWZKbiN[NEVQFKZKLS`DVKvUdAZUVMg°PMD¥kIEgFWHhQFAjHNSXA\\_lYQIqIEcCQJsJ_CFTAdDVdhWFI`ONE\\JDN`[feDSE]HWEaDgX\\VU`LR\\VDLOPCPRRJ^EHRRDPOHC^HLD\\GFDbLXD`S`mTIV@R`DFXRbVJHLjPMPlXCLLVXBHbnhINRV`@CLB\\LN`@^FDHWfCXLJO`Gj"]
				],
				"encodeOffsets": [
					[
						[175174, -46005]
					],
					[
						[173773, -45018]
					]
				]
			}
		},
		{
			"type": "Feature",
			"properties": {
				"name": "Gisborne"
			},
			
			"geometry": {
				"type": "Polygon",
				"coordinates": ["@@XLL@ZKVVFJXRVn`ZlSX\\FT\\EFJièĠİ¤nClPZAVQTTDHbVNVDbG@Rv@GJbXVAlNE``BTT^EXJCLFdPNBX`FZLHVONCNJbNJGRU\\UhPJTBTOrA`gcÜ§XA²Ŋ²ŘĎè~wGN]RB^\\VMXFPLPELFXENBRE\\]^JdNHJTNÌCSZQGRtKRB^EfC^BHdRGzHPGJOjGdAJCrAvENIIKkEEMJ[JInJKSLMf[ZM\\IXHvGPFtMRIVAZHTEPSxeVGR@X[BKKSOGWYA]SUWQ[aOKCKee[kJWcSoiIWEeGYQWAQFONKQk]MESIM]GY_K_BWHKbU\\BCYKMVIA]DMOIMUIHUEeSIKEWL_d]^SCU]IGU@c]AQSBSZ[RMEYRY^BLEMMgEMMEQPOBQOGJaGGeM@SGM`IbLHABUGK@URWYQYCgaQ]COOKAMJOC_DURQCKQCCQ[AIOsUIGASgOWUA]WCOIQaW@EMUSEOWHmSGMYIa[MamHOZWJWRW@]GaM]U[aKEDSC_F[NEZBBKUIAKW[WSMcHUK@MUDOAUR_OYSONkAaII@eOaFMCAPeLONLfJLANURWMaPDFO^seq`UOGQS@HTMLSACOWJWCYJ[K@²waCVMTqMKtFhGHiBIEeAUYERDTKR]XEJgEUn[@LpMdMTmBKTsITtZHVdBNRJGHWHi@oV{@SExC¿ƹÜ"],
				"encodeOffsets": [
					[181374, -39509]
				]
			}
		},
		{
			"type": "Feature",
			"properties": {
				"name": "Hawke's Bay"
			},
			
			"geometry": {
				"type": "MultiPolygon",
				"coordinates": [
					["@@JBLTAXfZ¸`NVOVeBSPJVXPVJDT`\\^RRDTZRFdjTNKpQHLZEVZNWN@JMEQZqX[TB\\KNY`_^EfS^BPITBP`ihzujfRB^bX`DJfCNZNE^LTIRZj|@TC`WRQN_bX`DVCRFXCN[X@LMCOHKbBPVGNFVOLBXJTCLPLGJL^CZTXDJKR@D`\\FRR@XPJZFXBlUXVXNXBNO`Z^ELUdQL@LO`FdCHMP@XRNB^dVRHPBRJVPVXR\\CVRPFPSRDNKB^HP`fƺÛDÀwTF|@pUj@XGHGQIAMUcYGSstJLSnANSNcKo\\@VmhFFI^WLQCSFQVZfBJFjAHGEgLsrNNSDUxb@±\\LZIXDXIDPTBNKGST@HRVPr_tfP]CEbOXNVQBMIKKePMfKODBCeGcMQBaH_RkPIPSzS\\LXQI@QQOgUcOUaUKUWDY_WYICy{GXFNMXIHAfGPKjclPFT^CJVRH^LHATRJANLTY^[NY@K]U@SJ_H¡R}FF@³CeA¯AwAI¥O¹[yOyOĕc_qQMEMEYQE]qoISWKW[WGOQKQcCOO_kOa]IwHiRYMINK\\TtFESE}B_HqRgZm^gXSRIPBXOVAPKZGNZPPMTEEMWYES{iYYcoOk@cSaGYAYJ]LS[YS[BGUSKSGUDMIQUSQISeCYUWOYCUI[[eOkAUJSTMOY]SCOH_GUKIeMDSQQUMI]OOi]MYKBeGiOw_uo]iKUA_LMi}GaYi@c[kLUPgPQ]µl@WWF[CqFQJFVKD[CU\\gJJXkFt[HENDXPtKRY@CJFTArSH@hQACfNVAXZb[NiJSNDVMLY@OFR\\CFNTCNkVCPa@cLDPERUDYJ@XiCIVQADQJcaWTBLdPXBNZPLNIJNT[LLZQXhZ@\\QHRtRVFxäOtVNHxbVIT}^`CXKFWAQJS\\@PVNELJL\\JTNJPFlNZYHWAQTWJWXN`C\\iVGZFjQdODeAaQKLiJDVPJRCr^HPZ[PMLAf[PNPK\\MLRNPRBNbZ@NqL[ICLPDPRATMHRPVBAPSNO\\Dh"],
					["@@IABfPKGW"]
				],
				"encodeOffsets": [
					[
						[180312, -40068]
					],
					[
						[182138, -40245]
					]
				]
			}
		},
		{
			"type": "Feature",
			"properties": {
				"name": "Manawatu-Wanganui"
			},
			
			"geometry": {
				"type": "Polygon",
				"coordinates": ["@@FPpLLLtDNEVLGVBRRPDJRFA\\VJMVDPIVLHNG\\LLGVB^H`DXH|bLRZMVDVTvCHIHVGXBNMVCjN^bbDht`WLJINDb^`RDPIEUHWRHXDfXANN\\RDLARNFVRPDCNjRNA\\LFIVF^@TDpCGVxqNbÁRAG[Ascu]aOEaYHEAYEMJIOYOKCIU_ceW_EQNGHWRSDUXLluD]_OAI[aCKJMXW@MfgGOSYAOUaJ]LCC]JjP^K@SUqo@]WacEGMTIO]BMhQL[KsE{ÛįĤkRQ@JTJfOTDVMl@bVPZLLlJJNWNCJpZ^V@PMVXDHF\\FHN\\FnDRLFVETNDTnDRLV`F@VdfTDJGG[lMRIBOlUCgP[TMBOUAQONGBSOQOCDK\\JrK@MaYAMOQQMNKL[MO\\OBeNK\\OOY]GqQDOICUjILKbRfBPCRcEiHYjUD[M_XWXIRSXBZGMYEkIOSM[IIKFKUM@OT[RIXBLEDW_~]JSaUGwUMPsãEwQUQsRG@[gYRWKY\\KMSJIKMYOAMOWcAKXSdbRICRBJUjD@WZIVCFQCOdKb@DOlUDMMSDEQ[PEZ@NKCUTMjI\\MYaBWMUDeRB@gTGBqESDIZ@LQOsCWFM\\GslEIWhIV[\\DLCEURIrE\\DXE@X¶kR^hOVOKB_RMISDYOc]@{CQeQg][O[A[WQOOgA]aOWYESKECYWSYCGM_WWHGEZOJWBQHaIsjUYaPSG[WOFgOTWOIgGLILMO]W_FIaU@QIWFQusbqm[IkbOOaN]c]NJF^NF`rYDGJNXURYQIT½BFO@WU@@MMK]HQcq@GSu\\mLSGKPñsOgaA_TUAOLSCOLgMBWMMgFeAgKWSSE]JQL]D_MiLIXVDPXm\\KEQHBNVNVb@H`h²NrTXÈFnF~@rEEPO¤OSWvUjWhuij]V[dqta^sj]TsRKR[`SRq`{\\}V»^mDeJ\\TJXRCN\\MATdFDH`NCXjJLP`bXDLHRGXnEZIPBNnjLGlT\\HELWPCRHHG^BXEXLVB|\\RCLJNYLQVCjMVLNULICoLY\\KFK^M@MPEl_^IRZDVlDVKJSAILkXwFCVKJBNYVMBMP_POQKAYdHJCRPJS^PRUXSAGR[BcPPTCZDLOJFPGPFPc\\QL`ddCHLR@LNGJFT^LXBJQ\\XLNXDDPETWNHR@X_fXVSLjJZXMNWFBRVZONCRZRNSh@LDHRKTBJQZSJCZOHBYXlBPbH`hJNHZEHN"],
				"encodeOffsets": [
					[179060, -39705]
				]
			}
		},
		{
			"type": "Feature",
			"properties": {
				"name": "Marlborough"
			},
			
			"geometry": {
				"type": "MultiPolygon",
				"coordinates": [
					["@@JPCNLNPCTgY@UMEN"],
					["@@PN\\BVIRDVVVDFLRDTXVDQYeBKGSNO@WUMQNYDccSFCJcQ]@MS[ISWMHMEQ\\KCGO_IYDIKeEKFLZTDDLVBLThFPKfJHJVHKPZRbFRGFTNN\\HRCSU`DVGJDMRtPZfFVUEWUoGK`uA"],
					["@@LTREKKQA"],
					["@@LVGTDRLHHXEFBjdDNEPTNFX\\IVr\\LVFTGN\\NrPHVVTH^IT]NDbZPPBBXHRfxbTTTRJHL`NGRQF@NMJ@RHJhMPBNJh®´BRGP@`LVNDhAVLRR`DRblLDXXpRPKXHL\\GPDTNZDKZD^Ld@NT[XaL@FohTRJNRDHTb\\KPCbVPN@dL`DFNbdHP`V~XPPLZBVKTlbJR\\P`\\J\\VN|PNbXDRLLAhBHLNhDbEXB`V\\CNPXGVLJA^ENh]FMb@FM[QMQrBNNZWOORE\\R[\\FVvHLJVCVJPRPAjJHJUFNVMF_QEKYB_QUAEPUJCTn^ZTLBXIV\\VKFVNDH`JFV_VNV@MTMJPLVSRTIJTP\\NPNEThEU[BKWYPQKGCQXEDI\\FTNCJjbR@NTXLILGX`HPE`^LDXX^HGQnQXBJOC_W@MPG`UGS@MMCOXD@UQ@[SRWCKMMWTW@IIQBGKSKBUTBZPJGQS_KOAGQY@YQaI_N]IPfNJKPg[OSOLSAGQKElYEWUAUW`@@KMOHUEIS@KQRKEMhHMVt@CLRPAPNZXL^CJMNCLThQtNRQKKCS]CWN]GCYKOhBJCEkiV[MNGEWWBSENMeIGIaCSBUGFKOOTK\\ZHfPHMQK\\GROB[K[YeFcOIiKmRJYOIMHaD]UBSTAXGF^VMPYfQX@ZFDReIaRIPXPjFTEfJJNVDZXhLBNYCWDUKEP`HDL\\HZE\\FXBEMRCFLVOVRtB\\R\\C`LJJB\\Fr\\SJYKSDKM@GRAXeOAEcBEQU[aEO@HTITUEQMcKGOQEoFWGMJRHG`PBLPg@MLEP^AELWJPPh@bZQJHRNB`KJXMJBLRRJI\\RXIEcYcLKIOJW^RHLRKNFB`EH\\\\TJTQRCHMVN[TINDPSVERRLJIRNTFELNZAP]LyDW_CQUTQEYSYPUGGN^CFLcV\\HNMLg^ETPBlINNUNFTVJ`E@QOOFKK[VSfJPMNZNBPNHQMM\\E`kXAKlBVKLTPbYZ]ZHEbPAVdUBERVJJCVkCaREVP\\ARHV@QQg@DU@iUCI\\QYOKTIJMP@vWTDA^\\JDRLB\\GV^ZIPDLdRHARNJBgQGK_qMDaISM@COW@@W_AF[TA@egHSJO[TGcIaCDJMfNhOPSkMO_C@QVEPKG]Z@VMN_EcWB[ZYBHkMQ]FKPWCGQVUWK[jYQBUk@RXWJEQSJKQ]NEaJSiL[PCcYAIXYAPQIWW@QGMD]SW@OYX@bNXD~AfNFF\\BWUVIIIJQRbPJTXF]r^`YFROJTPZAbTVBPINNLMOWtMLPPBBSRIAZVPXABQrJhDHMTDHT@PdPdZJCi_C[YSPY{CFUuKKOdaKO]DOQIZGF]MN_OEkA_MFKkBERVA@PHL^@DHXNENNJ@LXFQTeIW]GOS@DRRNFXGFYECSKGUDCMLKMWSQGYOSSIS@LUSW_Q[sKeCHUT]dKIS`aCQ[GHOCKNEVF`QlHTRvU@[HeNCP_OyCaBYLgR_^aNIfMXJTInKXBLSSMQUYOU]WOOWDScUGGFQMESYcUBUm]_[aUUW@K]Y@E_Se[BJTRBTW`[KIHWQ_PuADPQA]\\W@WOOASL}OQWBiCSWWMKMmm\\_UIYSQASNUgWeCkWDSq[_AYLQeMKY@UK_WCMQODQy@eQ_iHOWSOBASJODcNkHKiA@a]EQIIU[JeSYEOJQMK@AW_MGROJEYGIkGQHOENOKOseUK_[UCcSSCB[EG[DKEIU@RQUAKSFYWIM]YYeIMEYQCoB[FKUOE_B@QOW[MgHHXMN@PeVO@MKaBSFF`P@BZPbRHBNWBYGSFw`ELLjgBIHAbHHObMBYKIHkOkTIfhpEVIDwJAhEHBjPLFRCLWBWM[V@RHLYDIIIGH_FONCjNFAZMPFX"],
					["@@_YIMSNHNZL\\@"],
					["@@@NVLFC[U"],
					["@@IJa@xXDOGOPQUMG]OQULJJOJRVVHJP"],
					["@@^XaBUPIfMBD^OR^ZXXBJ\\NJVIJdRFPTRDSNCSeQSVIFQMULO\\ZANTFNGPB`EKdKOeLOLpRbRZ\\^RCNJHPSScASJI@UYIQcNOGSWQASWUEQMEEQPM@OQBDR_BKMWMIQCUWO_GKODQSAKOQEMFSUOGQJERTJL\\NNch@TM^NVARZ@AQFQTDfKRM"]
				],
				"encodeOffsets": [
					[
						[178410, -42167]
					],
					[
						[178481, -42119]
					],
					[
						[178167, -41652]
					],
					[
						[176867, -43113]
					],
					[
						[178080, -42000]
					],
					[
						[178235, -41892]
					],
					[
						[178252, -41939]
					],
					[
						[178002, -41849]
					]
				]
			}
		},
		{
			"type": "Feature",
			"properties": {
				"name": "Nelson"
			},
			
			"geometry": {
				"type": "Polygon",
				"coordinates": ["@@FMB]KIHUOWDMU[A_FWCaMgGKgAKBQKWCMa{OUMI[_[[OIQkaLSAUKYOO}W_UGOacEM_CcKM@s^_GQXcDBNYNBLgfVNFTLJ@^XPLP^@hfTEV@PP^NLlTRK^FFdPlVRT^JZVXGJHKPBVRDVELWAUYIIRMKhWZRd@DLbHVNblA`LPPFVC\\PJPPJPPFTTAPHNX"],
				"encodeOffsets": [
					[177761, -42036]
				]
			}
		},
		{
			"type": "Feature",
			"properties": {
				"name": "Northland"
			},
			
			"geometry": {
				"type": "MultiPolygon",
				"coordinates": [
					["@@PGBMSEOFWASVHJZG\\@"],
					["@@\\EQKIR"],
					["@@NTLIKOMF"],
					["@@@WIIIdTA"],
					["@@UG@UOOYCEKHSMSQBOYUDgOUWFWMCg[Q@QGUMDQCSUIKRq[GQS@maWHAHXNHPSHC[W@eiDWK@QOOBSTGOMAGZKROFSEUNCdDVVFJLR@PJ^[GUJ@TJTGVAKTWHKVONNRTAP^\\DJNZ@AXGPXTREJROBYOIPPB\\XKRZCbJCNUOgBAWWOOiAWMSWAaM[WITNHATMFOUqbKZ`BGPYIONQ[cXDXGJJdd`GD_IMQC_MIIPNbOFSSEPQ@@MWS\\IKO@KPKLRbGNKOI[@GY\\LTWISXDXLNMRTRsRHZQFY[F[KKMUAFSWKS@OJO@IJGZMR]EQ\\M@i\\SfWd[LILSBgCcSKHU@gtURsTMIJMZOliFM^ilIHOP@MeRLVMDKWGJSXNdaSQLELLXClQVOF]aGSKJGTHZA@SVGPYHSGYJ]IOs]oKwDiCqGGB]`SbWpCbB^E\\[vy kz¸¬§¶©´¥°MN³¾y|cVUfmtyz[T@TWXKX[P@JUVBThDFLCVH^TF\\jOLTJEbTHJbAPPFDYHKRHGXMPBJ`BPCJTZGDM\\GLLEVDJ^MHMCWJGT@OjNHA^VPRKRTCd\\J\\Ox^G^TZGTQ]UAS]SEiDATOBKLM^RZMJQbISRYC[L[VSD[EaGSYWODUXaIQDWETOCOQ@aQGHQG]PSXWmS@YJBMNKRAT_aFIiUQHIKWDOVIcSLgMOW@cd¡®YdGB_fg^S\\GRB^RPPADNRAPLN@LNQHWQU@KKKTfFEHSEUHEKJ]HGOMC[UACXYdMBI^WJKXMJIRDPTOXJFR\\DPRUT@U]C@KMMQCIBan~WNARN\\VLZEXI^BPM\\BPJ`^XlJdFrAlGlUaYlexwgnOXsvµÊªsvSPEROV}qpaZ_`¹¢SLMG_NEh_`cFUR[A@HfLPJJRFbGXANK¬SHIZIZC\\B`HbP\\VL^RDREdAFFfK`AHIpFPCdPJLBPVDBLVHfK\\Y]EeQM_GFkGQ[G]BHfGLcMSBOKOJ@PRBYZ@LUESJSCDMTAHOXASWDKRGm[SRSD_CHGZGLFNQIMiAEQnGPP^M^d\\BQ]HO]CYOXAHJRIMWJIRPTdNBRGBKPM{Q`OHMEKNWBQRBHNENTPCPFdupIR@XVHhCHKDiVLkRiVkdy^_laaHSX]ZOHWPOR@HQIO@OLICOUBOLEPQAINBTKLBNWRUHOGTkTKASFKbQNHVGBUNSjadQ|OIXMBMUSC[UCUQWEDIKYQ@MOHoHQVIHOVJdI\\BLHNSVDJP\\FPpVZMnKXIZGFQ\\OAEZYbANNHREzFTbTZ`@NS\\VJEXHFTWCSDORGUUVMRHlJBOOCjU@Y_GSB@MmWWCIJaDQQE[F_PkVaXYzkt@HIVGLLfCPFJCjHRGAQNYPGN@AVFLE^MPWF@LOFI\\PXbNPNJRNWLCA[vVJIZCvsVCRPPER^VA\\IESFUPCFKKSLIlFjMQI]JI@ESnECUO]QE[@MMCQTEGONK@Uf@JPCRHRKHZfZQRvO@UJNP^AZJVBVRdQVNZSBQNKTCJHVITRLONARMGOLI^MDSM@AQP[BUPUZONQNBZKRPRKZ@FJRE\\FVGRJVCTDXWGEZ[@OZ@^SMSOHIK[HQMWGGOOCIVJBUdRZ_FCSWIMV_P]KKBOOHGhIbUX[ASePeUODEKJO\\HTIVJdETJJKTCIWDM`KFcLUIIOJAUTDTIVQDQ^_BIQWMWTWHYPGNJ]NK`XNANJTTFBS\\ORDXGARgCDZbBVE\\@\\ELKAUfFMRULcfGISFKCO\\GSO@WMOD]CH^ELNJLOXDCPQ@S^_`NJXGFSX@ZITYVH@PTEVKRQL\\GPHXJF`GOODWjV@|fLNCRP@JPYJjRVGLLRKUYQDU]EUMGMSXOCKVAVBBKYEIFWMI[HSXMPQAMTAHUXO~@_MCKHMfENQBMQILMMGUJCLD\\KPO@cLcRFHOPGQ^UHMKKPMPJTU@ULGCQPKAMJIFSVHLMUEGUHIR@LJZCFK\\CXJNCB_RQRELW@GLOX@DGG[]MYPGKfONHA_ZmV@FKPARNHWVBTYLANUDOSMNIWKXIFWQQo\\_USBOHKKWCNMjECP^@FKROQ_LKHYPaCQaDJONRG_KPUKKLGPbOJdJIUTUUMJGEeHMIQB]PePYb[@WSEYFOG}PXRO`gBOEQVVHBHObOPOK[FFTTDCNiDSSSDOI^Y_DKPOJWDSZ_RQMDIWMIJDPLPSPRNGJSE@]W@[OQU\\SRUEWUKLMXEQKEKQKbErfGTLHNGFeLXNAVOXAbDBQ^B@JXVLCLQTKbDRGBMmgScKq@yFcNcRcAOXkFJ\\cXEjax@LJXBLI@YRiSGBYNUIQOBGOZBRV@ZQPLLd"],
					["@@[E@TNDNQ"],
					["@@RLPMBIQMQZ"],
					["@@JHTADQQYWXHN"]
				],
				"encodeOffsets": [
					[
						[178921, -36821]
					],
					[
						[178920, -36748]
					],
					[
						[178928, -36335]
					],
					[
						[178936, -36301]
					],
					[
						[178808, -36984]
					],
					[
						[178380, -36070]
					],
					[
						[178405, -36056]
					],
					[
						[178110, -35833]
					]
				]
			}
		},
		{
			"type": "Feature",
			"properties": {
				"name": "Otago"
			},
			
			"geometry": {
				"type": "Polygon",
				"coordinates": ["@@V@\\JLExGPF`CLZG~dTFLPdNnHRHfBVERZ^LdDJPVT\\LPPrVNGLQdOVMZCHJEX`^XARFRVlXFNZGhRVAPHXCL^`IVEXNH`HL`bLXAJPNZEJNCbJTlJUdCNfF`JNLKNDPPBbGTFVLb@JXbB^HTLV@VNL@J[NUR@lKbH\\ElH`CfTTfLLBVdDXEDOPOAQT]^GfS^CDJhNBJhP\\RPh\\PlFdGRBdjVHlBbAFVTVDdUTHhNN~BTKnN\\BrELIHiP_KIDWXeCG]E_@KMA[DK_@QUJMmgGaWAKUDKkWNOiOGKUIQaEW_C@QJUnST_C_KWCaHEC[GKD]PGCOQQFGI]QQDOPOCK[UKQV_[UhWbCXF^GTFfC\\eM_ICF[PMJ_XEcgCUBcES`DtIRIdDJFJrZR`kB[TWGMBiREgXGhEJF¦lNCOh¯NVUBYVcLuCUT_LKLYREFU\\MjMLaXYYU`GTYbMTANNELCVHrFVJ^AbHTZjEfNVIFR`PjATGHeIabFPYIOBW_UMMJeE[\\_LcXK@OJQXEdF\\LP@VLNZVPbAPXdRJJDXVHJT\\V^HRJV@FVb@PFRIHLjTSbLFH^lP\\QVNENj@HF^Bü@~E@Z^GPHPCVD`G`OZ@Qb@XGVKrDREI\\GvAvORI{ae][meqs_YQY]BKTIKYYA_O]S_[]aHQKC]eDYWMSUM[FSIMFI]YQWO]KoHeNQXE`HDQAUJMASUFgW]]UmEWDM^MLO_QIMwkIOm_amY[BgGOSKOQWOIPOB]QKKWARcKQCgi[_I[kqGMUAYVMbPDLbEVMMMBM\\JKLFNP@\\a`MlBn]WSeDQMIYBGSJOKQSFiQOYIGU_WIgI[AcWJQRDLPXH@nRB`NRVGlNPJGTZEFM`JG\\dZPJLDXXDFmJOUMK[E[KAwL[MFMVEZLHGYBOPCWWSCKHWFoGYLZFKZiLNkdmMA_O]NkAkBYMUA_I{FuCmGMMkAOkCiGmEmIIMsO]M{sSWOGekWWM[OAGQBG[QMI[FEO_OQkUukmO[aOUSsUWMCOcSWWS]SEMSGmY_GSwWykGYGobYEoHKAWeGFS]GODUYOHeEKYMEDMeQHUWGOBw]m@WCCQOQ[QSWGR_RYDMCcHu@kGBM_SU@]OU]XBBYoPWQ[JY@_MGOLKCQLIJSKSPkD]NRHY\\HZiT]F{XILdB\\LRXRNLbMFUA}`cHWLHRYLEHHXZFPTVHOXRLCbabeNaASNFRRPDR\\J^V^P[JhdWJAPMLXLAjCJTdSN@NXVBXWVgDBNQLR^SROEOJUACVFR|ZIXLV_HBN[@FN^JJXG\\_@gX_FkhCXDQJcIcAAZIR^^ZLLXERMBaZFLPF@VJVTVODedPNqPMQBI@@`N\\\\ZFZ_LSPBEVMDAPVLFXCV\\V@ZLdVNR@^X^NRbX`d`AJNJTAPRbXRX@vJZfGdUV_CUTCN_hDJMVeB}dKlQdWTMB«­±«ùgYyTB`MJeGOGAK{Z[G[JVBxaFMIfwTAFNpK^DNKRDRSbFTQJ_GSB_a]IUU[EUB]KIK]QSQá_ŗEiAVJrQTSLXh]XYDaPKTHRQ^SHHXmTfVTPjPHN^LDZATPRBhHNKJNVVNSV]CUQyAWF[PATWJcVOPQDD^_\\_VU@KXNFAnIHEbSBBXJL@XNbCR@LjTVD\\PNCTVZHPULWIERU^FdHRRJPXORL^KTZFANfRHBbZRArCLXXXLbLDLZddEVJbC"],
				"encodeOffsets": [
					[172375, -45564]
				]
			}
		},
		{
			"type": "Feature",
			"properties": {
				"name": "Southland"
			},
			
			"geometry": {
				"type": "MultiPolygon",
				"coordinates": [
					["@@EPV@JIVAFKkAIJ"],
					["@@GPTT\\GVWQGAKSMODJVOD"],
					["@@RKQGg]UIEOSFWTjbrPT@"],
					["@@WJAT\\KAQ"],
					["@@^IUKWJPL"],
					["@@YHDN\\CEQ"],
					["@@KASQGYOFD^IF]DQEORLDZELTRDf\\PDfQU[FIQI"],
					["@@JRHhCdILSJLNQpSHS\\Ohk\\fVSbG\\DTR@RdIVnPX\\RCnRRI\\B\\EPObDRHFPVLTEHK^CNKnATQPDRSTG^EFkJ]NUZEIOHO^WZ@LIEKLK\\IfCJK`EWMBYRENHZM\\GNPXODMeMNIVHDW_GBKTAHQUA]N_KuHEN_UQJB][LY@CPTPWDMRHNcBEQYEYWPw{SOUu_h@NL^DNFPTXJHTZBLJhOP]`BpK@GhCAMMuOqULOPHfCFEd@FJ`N@NrBPNMNJ\\E\\VJJCHSWEGWVIOSLUXOPCRYQMRQVHHIOKaIT][O@[aV_KL[rQ^AAYY@KNqNQEWDGMPENUMEFQMCMNkJXWBIkFCFmJSNOIISUAYMeBGNYAeMGOeIOVIBcYCQeEW[cQ]NCY_@EDiYY@iLCN[Kg\\WKeKSFA\\ORoYM@OaHKoWYAMM[FUASIZIOOiAKOQAOPME\\Q`DlLXGdDCJLPLD^EFOSMHIMQCU{GOVLT]EUI@OWAGMWMwS[@IJSG_NBRYIBG[GWJATIRXJFLINPtfJJRlHLGTT@NXDLNpBLRD\\]DZRAXP\\IN]XAR^Jp^FZVRnVlBvOnGRLQXYBJRSP\\TQFKTAVYFN\\^ENfT`d"],
					["@@ODNT\\EFQ_@"],
					["@@zJXCCKXIV]SG[WKHQESLG^[RJP"],
					["@@MHBPR@EW"],
					["@@S@UJPP`KHLXOt[R"],
					["@@LGRYDCHePGNWRINgTJHDTl`BVd`LTn\\FRZNRW@UIQ[QCcJYbkFSVKFKBe\\kUC"],
					["@@sDOFA^^RxFpKbDNI@MOIiIECoG"],
					["@@\\LFTRPXB@PldD^ZPBNV@RSLZbTZCJRPJ`OV@THpFXHZOPAfaGSDcJaE_NYGaIWYQSISOgIGXS`A]eOQIRQLAPTH@RoDTXKN]ABN\\NWFKLS@YO}mWO_[K@KMSEGVLVTNDL"],
					["@@H`TFdKEU@[UBGR[D"],
					["@@DN`IOUSR"],
					["@@]FIPVLDNZJfDLIgoUC"],
					["@@GV`BFK]K"],
					["@@oEDVpBNTr@fHDFrPlDvEeWmGaOcESGC"],
					["@@_QcE]BA^LP@ZPdCTEBOSEW@SG"],
					["@@[PLF\\IKK"],
					["@@`ICUsOTG^f`NFXC"],
					["@@Q^RF@c"],
					["@@tE®gtAXLVA`FNNRD\\RbCRFRMbFTGh_bBLG`BHGLgO_HUfSFKCQbErCDGGWSGWAAKsWOKDQZKAOKMBKWYHQ[[K]BOaDUIcFYcCKaKWKWWDKBqYQAaQGeBMYELSK]PQOWQIGQEcV]FQXJVKGOUYDSOMC[SUKi@DQMa@WIKAWTAFaJGBmMELWV@`U`[C]RCPOdUXIBS\\OXEzBVR^DTUUMMULIGMAgOQBSCY]KGMiOSOeUnSGWTGR]GQLSbOZC^WWgTKRSIqBUjŘFâ`TR^RJL^LVA\\FVV^J`bTA`HRIESTaCQLQCML]MoBExSeNJbEAwIU\\\\H|YBLPHfHNIA_zShZ¬ú®²¬NAXSRcLk~cfANUCI`gDMVS`DVUHcYeuIW@WQQaBOISMBIc__aWMQ]]WQ@UMKc@Y[UDUEWUKBONCFUATO`KEY[YM[@_@AJNRrOOMfcPCSUIU@UOEEKbYNAFQKWYK]]JQBYdBdJRICDWlg`EhW`@H[IW]IEM\\@AM`GKUJW{YEQDUVBPIPFTQQ]RKAMhCXUAWWU@MTMScDIBiWKNKBOXIgc\\I]O]U[ICQQOEQTMbBfMbaDaQKPWUGOSYEGWFGZKGQXKdG~_VBNEKaQMQW[KcAJK|W^EjSGYZ[QG^MUC_UEKYHQWQO_KOPoBOE]VAXNDRPWLe\\OANeNKIILImEQGMOBOO_CALULU@@VNRWHOaMQDQPWI[AYPEJ¥FaAEIR[NIhNXENs\\_~KDwSnIZAFKuNkHD¡E¡Q­[Y_Ea@wFo@UDiPcDSABXLJGjITJJIxGMZHANQJGPeDKJ_DkJBQQ^JNQFQRQOUEKDiKI[PW@[`C|ULQGQcKQDSRGdIHqHWVFTSZmJ[ANRIXKHAX\\DhEZNdCMM@eTPIXXN`@fL^PZHLRPCJN_DQRMxDTSJCRYODiGQCKOVITgMKwGYRKZ_nSpINs]Z{hqXRcBcCaMcSASPIBY]BeHOHYDMJUDYLgHsAeMIOROGUiJOTSLcFaKGMQK_CWRQFIRS@_R@PNReZMEmJINLV\\L`DPHF\\O`[Z»joV±laLqJHAaI@MOaUMSA_KIQVSDaGUUEKQAsJCQI[E[OSHcAeDPSE[A]JuReDWNSAKLkG{BTEJoGsBOPaCIH{M[DWKWEiPaAKHYCYPcCMIT@LUFMX@TUFAR_DLTbRPLbRTfBHPKLF`^XJK@QTFOdXHrJHXRJ]NPªRtTl\\LXTNLNnTKJOEqaGFYMU_eCQEgE{_KB]ISUKYRCLUTIHKCQOAMMQAL\\@NWACWOGSgUPFTS@BTLNTHRX@PscIO][iKGWSBIJsRS]cGDS[GIPCX`VEPJJEPHNTMDSTCIXJNQJV~RZhRrD|PtC~NZINLWN^T{DaIgQSF_AcJ]DCTbhZLTbCjWQAUYU[OO]gu_Kc[SBSGSF}iODaOsLE_SDKTKdLPILCXDd]rSTRVCfHVKRD^\\NJPATn@LPnR^@DLBFF^DJOj@[SVARJ\\JNLdDVHzHjJLAVH|JPH¨JpE@O^GIX^@HbP\\Bz@|RUTPJNX[HQ[AWWFmKyVYEgLKLgBiSOKE`BRPXH^VThHrFjHrRpHX@^L`CXRjBLFdhcMYUeAsGeGYJgKcQO@qQoIiCUDE`DxM\\NL~FNCdbZPLh@^NfSnCZ@dRfFjW@ReRaC]KcEeBWNDTlRLpk@QMOA_gI_DDWkSYBwKGDmSWHGSaIWK£IOB]PCb`\\XfEZPeVAPXTdCNPHBLPR\\@VJpB^OZEVSZKh@L[XKJJQHGPYVIPSKwbcHe\\YAMHARLbJN\\VXhPBJPVDFXTZbEf[\\IbQjAlSYOUCSKDMZT`F\\NP@\\Y^IXM\\CJIOMCMQAHiLKAW]DaHcGKKqCQKUACM|V`A^NTDfG\\IXR@XS\\LfVP|OVYZYJ_RMVi@cKMu[UQFOSMHMXTANVXJ@tXBP\\P`YDMXAOVaXY`FR]f]jWRKR[RyLaVc\\@NPDDRVBRTXDjEXHPATHb@\\H`IHch[pAEN_AULIP@V[\\ZL^dGFiaIFiBBKUQQDMcBeI_LKPG~SJETODUxBRP@AX`\\gj^VHLTBRdvGheHUVSJO\\KRcJEvNHPiIMFQ\\QH_lKZSR_R_BDPVJJX^TJPVPX@P[DSRET]bOEML[CQ^YTGVHqRCTFPIPDLdH\\G^DZGVFYL[CqFIH_GWNebK\\QXCRXJWNfLJLZLXSxEpA^SXEZK\\GTBdKhBVGNNUHSEIHsLcCliFULmBQCCVMNT\\\\NVBRT\\GFLKL^ZNVPHTIXBDHcT\\JTNELVFFPRHFV~NnZHLX@FkHQTIVUDWPOAYQMBUSKfIbDPQHSsabCJPZLhIBRSHehcNINPNNMLDUT@^MPBVWVQ^@LSPBdELdNhVLNbJNTFGZSxYHOcYUYYOEMF]`WjQNHy`KRVNPZvxFLYPK@KTa\\AXQDFRf^ZFRI^E\\FhILDT]NCXgAQTDDRW`BLoZ[BKXePV`b`HTLXCXQb_R@LN_ne^`BjPBJ\\Np`j@ZHVl`@PLZE@Q^GFYNEjAZORBXUPCFUj[BQTKD[JMZLUHANZCYf@pgD[NQTcLLJ`ArRdB\\ELDXY^dHTNFPTVBXfjPFPT`NBPVDNT^VdF^IRJXZJRFhIV`JLCBFBbMjBPP\\nHRUX}`YASN"]
				],
				"encodeOffsets": [
					[
						[172157, -48059]
					],
					[
						[171720, -48327]
					],
					[
						[171451, -48357]
					],
					[
						[171692, -48354]
					],
					[
						[171401, -48344]
					],
					[
						[171705, -48342]
					],
					[
						[172578, -47898]
					],
					[
						[171787, -48059]
					],
					[
						[172274, -48040]
					],
					[
						[171626, -47880]
					],
					[
						[170641, -46678]
					],
					[
						[170910, -46379]
					],
					[
						[171000, -46387]
					],
					[
						[170829, -46848]
					],
					[
						[170460, -46803]
					],
					[
						[170502, -47160]
					],
					[
						[170529, -47128]
					],
					[
						[170555, -47112]
					],
					[
						[170583, -46883]
					],
					[
						[170640, -46877]
					],
					[
						[170530, -46859]
					],
					[
						[171877, -47576]
					],
					[
						[170641, -47205]
					],
					[
						[170698, -47211]
					],
					[
						[172087, -45320]
					]
				]
			}
		},
		{
			"type": "Feature",
			"properties": {
				"name": "Taranaki"
			},
			
			"geometry": {
				"type": "Polygon",
				"coordinates": ["@@AMFSpDNABMNGZHhBNKRFpGVBXSPA`RLC\\L`GTSPGHWVGPK`GGMYFMGgIG_OakAZWAPGDYTIRYAILSGQKCg@MTYQDQPMUYAQXENMYWiITKWU`e@WGQXMFSCOWCKM[WIRWA]KESHIKMQ@GKcD_cRKd[EOHOEOPICKDYOSdO\\AHQTBVWOQT]OIDQGIZcLBPR`ONONAZUAMLIDUxElWJKTBLICUUkYCJQ`]FkNON@L]LEZ[pKJDVKKMNUDiRUZKIMDK[QA{KUFWAWH]GGDQXOFK[GkSKHmiAMJOFYWmQHKGWC_aKOiIDW_MCGEScNBM[QDIW[SfISK[E]B[GcDUJgX`QBV]D_LgBkXed[P_HONqV_TqfglMLSZsx_Z}^YR]HiDk^WHUP[JkDg@_LaB_@{FMAiXkLoFQHYAsVaFMX_P_DKZa`IDy|kXCLUVkVKNERUbQlDT[GtIZN`HD^jCXJ`JHRfVPXJHP^JXZlZFbZf@`FZRl^`HTPJRKTB^HPAvVZXRDdZfDh\\HNZFRJj@hJtEf@lHN@ZOnEdDbJPEhPh^VHNX`^dnVN^`XAf\\RTVPrXtPzPrF\\@jLL"],
				"encodeOffsets": [
					[178806, -39635]
				]
			}
		},
		{
			"type": "Feature",
			"properties": {
				"name": "Tasman"
			},
			
			"geometry": {
				"type": "MultiPolygon",
				"coordinates": [
					["@@heAKZMAMdCRW`Ht]UODaLOa[GSQCIMSQpg@EbK\\WMSc@]KYCLYCSMOC[HGKLWQOWoCWkKQa_CQQUKgBMCKU@_HOAQ­³gMIOAgNGI@QNI@MREHQ_MGKQISSaSewGQAWOAYOCa^MJSG]USGUqO[MHMESKUq[JUW[MEOSMFcCAiFEGWKGCQHSKUgDUKGFK`EBiUeEKMC[TSYQacCQD[JQCMmcSE[BSI[cWGGMYQCMYG_DOM@GWA[FOSMaOGWHcFd]@MHRTIXKBITMDBRXPDJINA\\EDBfHH[t_F¯@QHIXYA[DGL@XGNODBNmMOJOG@KXFXSHMRUfBHXbFZMHSAmJUTLXO\\BRaLA\\LNNBHPRRQTIXNLNG`J@`RN\\BBâQ@OJEVFNdVBNLP@LQHTTHPTCVLLVLE\\@ZTpKDTXIVBJMTERPWVL^]bA\\hNNJZGHIVDDVNJjRTVH`OpdJ@bDLGhVJf^dFLVpRBZJHC\\PNARQBITHHdDj\\LSlEhAHGrPDHdFL\\^NXBDVGLFNEXNNCPDRPNFRGTUHGbOLBPJHtBjVVElNHNbTXVDVSPSJ[IkEQFUkXKVSBOXYRMZkNW@CJHTU`gBKVV^E^]@YDuFIOcKUNoJa]KODMYEBOoBERLLFXUNY^^jXR\\BhXLTVXIHIVOCcJmGYXUAULNRKNM@MJNTDVGHaFSZkYIFIZBLVTEVRXB\\YXUPMTpFRLTB^XXFXPZX\\TlTr\\ZZNXbVfdRH\\XTF^RXFHPpRv`BMLKQSu]EGJMj\\N@vTNDAVLFrHfCZJIRFXODQMIF_KaJKS@MiKBfrnf^JldHEbD\\PnCnKrAJxCjG¤EKQvObONMIIy^yRcH{DOFFY@WD·FsEeQOKEWa_em[IDMXE[Jc_F]YDKXIF_hBDY[NMRHPCVaruNAXSZOpQ@MfcVJhWbOJP`CbFRRTBALNL\\DRQBOLAFRNLGVHVNJXEbLHURUPEDWQ@BOTaAKTQmKAWPDXTX@jNTUHYQKO@H[TOGSSFTeCU]KFI\\GTBEQS@[QMagAKIAYKO`BCKJYMEPUeMEQPSpcKKJOQm@OUCASPYRIZ]RBM\\piLW\\cC]LQ`SFISKgAGIHO`MMMhKRLlARW\\QFYjIROPB"],
					["@@WBQThCBQ"],
					["@@VI [\\QEKWNa@UEWHIIWNOBGPOLDRRFPE"]
				],
				"encodeOffsets": [
					[
						[177357, -42322]
					],
					[
						[177336, -42287]
					],
					[
						[177278, -42244]
					]
				]
			}
		},
		{
			"type": "Feature",
			"properties": {
				"name": "Waikato"
			},
			
			"geometry": {
				"type": "MultiPolygon",
				"coordinates": [
					["@@cKANXBNC"],
					["@@@ZTJ@mSJ"],
					["@@DNRACR`ZFGG[oS"],
					["@@EIYBEPRHTO"],
					["@@AV`Lt^TAZHVULBfbXHRN\\BBJ`LP@xMXQ\\@ZPLLvALI\\JCPJTKPfR^@TFDK`_bVLPNCTHANbBFL´B`QTHBHTNJnAPNDB`OvBVCPJXCLBXPNCFD^GNRL^WRYfJJL¼DpHDSTeK]BYPWMKAYEI@U`ZmIIV[VQvUGpFvLnTnHPPJ^FDNEZYtUPBJI^TATKNFLUSb@ZSZWXilML[\\SZIbKNOfbHTGRHtED^_G]HMIIJ@TrGZHUJ]FYCFNNL`DbETRRK\\TFfSAOH^PONIAKRQHJb]@MTSKM@SZEbF\\PRN`AdKJC^bGdJMZQGSBEJ_HM^[NCHoVaHQRYHEROPANMTHRErHLPGTNDPb@tKVJLKP[RMCShHHK^c`IOhhFh]JUNK\\BAYYCLKCSHYMORUPElBFQZOPOS[@[XMQQqNHiHEb@FNpILKEKLGEO^QMOOmLOVFFQhAU^HHvEPJyJMX~GVDz@jLCH\\XJEfD^NJPNICQPUZKZBEeYB]EKM_CuOG_A@UmA@]NSEO]KcTIIR[PN@]KK[E\\OXC@IXKVlQ@GfXTCNjPLOXEZWFSNFANQDBTEXXLVEVQpUL_LECOQQLUZGD[d_BmYECOFWXSDiSMFKegCSJKNZPBLNCVTJPa\\KDMCYN_GMEwIYRGFKMK@WKKJYEEHkRYQMWVIP@TMROCAKPMQI`WTE@YNMIUNAT[GQTuV]FOTSAGJY^c@MKMF[WEMDKIJOG_YADYNQGIe[QHGKc_VWRHbgDMy@YC]VU`e[FSQMCMHKV@F[NSISWKEMKABUfAMMMPWVoZKLQH_JMTC@OPECW©k«|]MGF]RMGYTF^UMYl]fO}QKMRwTUNDLKA_I^MXUnYJIMYjSBMBMMLONB@gNP[h@©b^rPHYTFJ[N@JcVCpZFNRJ\\I`QJU^SHUVABOTY`W@EdY^[^GN@fZXE@IRSD[KOBInCJSK}oßAMDiEOUIYW]gåčċŁFçYMFUKYRGLoSMciQESYQC]Q_[CSUIWOIUTOfAPUMU·_eYBWKSIAkVAPQJkNH\\IHSCce@U_EKUCQSmMCFSEUQKmC[EGM[EGEWCNU@O]UoYDIXMIMkIKKOYaUk@UNSCePSI@IRQģlÜİF|LtK\\gRANP^SJHNdFXb@^rpTV@]LiOID^KDI^VbBPTZHPeh@NWXINDL\\bBJ`PC^kvWKCVQTGXMHFRX`dfV`DJPLPZIJFNBZGFbZPF^bdvBtH\\QBaÂMwrHUoDSC]@UEEJ[KMBiQDMOCUQMEBQCK[QMMWBCeGWQGXFVOJQC]_CaJMKI_XgsaC]aiMUDMNWAUHGGJuDUSUCYNKQ{aWG_C]GUAKH[KMHKGJUCONUUIB[QECIQOAQHUUKMFsCKKoKEO_HOLUHGXOHST_H[KKD_QOBWTUAoHQEMLgAYGMHANMBoCETBNFJJjF@VJ~IxNTA^HHH\\E\\BhOrHDG`jBTfPVZTZfXJJbC^FH@ZCpIpNLCbG`g°QZATNHHQKnZPTLZJIIGC[RICYXIZHNLJ_dGHNXPAJoIBNTJER\\JfGND@LbR`FRL@L_GWDHRTMRRWVK@EPQ@MI[GYA@bUGEaWSKOeASGAlJtZd^T\\HCYZBHIN\\NN^pXX@HU`SG_BYK_K@QJGGQXBLEEMUKkKODE`QZDVJJEbU|QjMLLHBLMTTpTZbPfDLCTHLTRLRE`BBPZFPMtCVNNEPJLGHTTEVO@XeRaMAOOCATSEER`RJGfEPDHNSHCZKAiNkcNCUaFOiLQAcYWAKHKKjKNB^Qp@VWvIJBTiKJAUrQbKb_|U^OjMNDPIRHPALLFBPM^HFbYlJP^TLN\\NHPXtV]FG_aCMNM@WIO]MUHQ`m\\Ux[x"],
					["@@K@@ZRBT[Y@"],
					["@@JGEOTADMGGpSP@XWDQUI£FFNRJBZKTcC]d^@HHXD"]
				],
				"encodeOffsets": [
					[
						[178986, -38220]
					],
					[
						[180159, -37944]
					],
					[
						[179641, -37678]
					],
					[
						[180000, -37311]
					],
					[
						[178852, -38187]
					],
					[
						[180155, -37508]
					],
					[
						[180000, -37459]
					]
				]
			}
		},
		{
			"type": "Feature",
			"properties": {
				"name": "Wellington"
			},
			
			"geometry": {
				"type": "MultiPolygon",
				"coordinates": [
					["@@UAMRGLFn[OWUCJWjK`N^CRK^ITFXThLfBhENNAXhNPKTDPKVB`SbBPhtòLOTHnKv[HTr@Rd^GNL@NV@@XEP¾AJSZRVQMWHIZC_qMEE]I^M^dbMPPla\\JrntaRvXERJV@Jb`E^XNPJKKhHPJXShPPE\\XTHbOVZtibJRGXAPIFYHXGMI_]M_]]DOGSggAUMSA]GYS]EWYSIMK_DKROmOSQiW]Ua_YiGc[[OIEoKEASQYI_KEOaBUIIDMIO[OGIuU_EWIQEY[WKYIG[A{QkSuiAaK]gWYaQCUYcGoKCOaOOK]CwWSCKMQBQMgmI@QUWMQAS[UGQQUFOMiKSDIQYAUKCIY_YIaaK@c[WIMJC_EMGOYYKe[]@cKaHQJgDOIMbFJOJGTAdI`]RKNZpAtVZFRIV@TaXb}VwP±XoUMK[@UEQUcKyKBUbaLgJCRVZQVgdTpZVBNNF^f@JZV@NNdMRMDCRSL{NaMmQESOJ]UCNSb@FWSQZGZhHZNQ@_GSTOWOGSUBU\\SGFKMMaBIIkD]ISM]BSTWBMLcByt@d[DITFXN^plT@PQXT^LFTTHXA^~TN@PlNP\\fbRZTJCJZLjHDRTH\\GBGU[UEEKFQd^TXCXHKPaNOCWOOdW\\WHNZbNPX`FXAZPdbXJhxRbPpD\\AdFVLRlXjXtr~`zl^|"],
					["@@[EAJT^VCK]"],
					["@@VXRD^bJ^fF^KKI[eDEc]KESS_SS@OJDPTR"]
				],
				"encodeOffsets": [
					[
						[179339, -41676]
					],
					[
						[178980, -42080]
					],
					[
						[179078, -41849]
					]
				]
			}
		},
		{
			"type": "Feature",
			"properties": {
				"name": "West Coast"
			},
			
			"geometry": {
				"type": "Polygon",
				"coordinates": ["@@NSVOZWA[QWFUUSAKJYJElZTYbEHGCUMSNIN@LMMQVKVBZWnHdIPDJUJGUWKSgW[AWQ]iZ]VMEWKKFQpAAPZFCNLPb^pIVMdLJPvEZC^@F]U]LUhAV_GSDIX@lMNYZQPWTALUlWVRElF\\JTITOCUWUaSGMkMUFiUsAIGAOPKHaVGHSEQOMCQDOMMFWEMHKCUWA]MK[cECGqOGHgBkFKTi[cCGGJSRABQOMD[IGAYoQKUcEe]UIHgCK@acIPoG_SUiQMICUUCGJYHMIgMB[^aK]XUQOSFINUAWJCSoLYS[@KFKUUKSDGOSSRG@KKOAMcUEMFUPIR@Aá[AQM@__IMHMKJWRSQQGOMAKMB[bKAQP[KWVSnITBNGEYWaAGVeNQTGEWLW@PHPInNAMPCHM@WHK\\CZBJWRG°@`E\\sGGAeFCB[JMCIWOAQNCJSLAJWQSNG^@cdEXGPHNbPT\\EXBBQKUYUAaWIK_NSKW]KYWmL[SOIS_UeEBKMW]SYIWF[II@IcUUqWQMKUDWISkcYBUEIKigSYJYIGGUMESBwOUAWIOHMC[]AeSYCBKYU@KOaMK_OE]DKQSWC]SO]Q@KM[CCMkP[OWACSOcRSAQOOcCGKHOEGZSg[aOKMSKGPs^YUqKyHSFaGOKBQCOOMHERcLMSeS_L_WNQGKUB]_gIFXUCYNSDaYQNiIYUJOU@]MKI]KO[YAGGDUHEMMFSMMQEGkQC[QORMBOSeGQQMJUB[IAYQWSJCJ_AGSOAIKLMw]GUTYwUMeQEUg[MIGHHbWFOEaSESYMGIgSDIUYLOUQ{COMCQ]I[J}eUAkH[CUGVWEYCSQm]XMASQI]IDGgaC]UDUGWHFPWF]Iy\\UYMI]DkMGQUSAQoIQOOGQU_UOSLWF@LWBmUWWD_EcUCIaWGW_O]BUK@KWCK__DuOKWLII]PYOWCSiYUKeE[QDKMQJMDWaOMQsIGKPO][JQSSMF_AQUYMSFMOMiHYOa[@YYIWAWMS[UAUIKQMuWFGS]OOWiEKJqF[AmMSL}AMMGgVSCcSUEUaBkAUGciQAcHkE[OOg[QgOAIgMCI]DeT]HS^BROPCPWFcCAUKKSeeS_DkG[FaGkLQ@MVI\\K@UMU@SK]GaAIWa@UKSEaHOACOLMMK_IeEDMVckIISDaIMYFMIOWBaKK__GMGFWJU]_DKGWBOQUHgMYWEkQUQEWB_]FWGIYDUNcPKRMHqUOO[KUSIOcC]KQYUFeAQGmGcMKOSE}cYHK_DOEwHKF[IU@APL^\\\\GRXZALLNBPYLCRPLtXBLXBTHHXCHqDaFDRELeTGVP`KhGH_AKHaAg`SHaEQNQEaD[QQCMM_EUBWKsB­hsF^T^H`Al\\r\\JJHVbR`JfPRhFb\\LZPhNFHPvT\\NFPMLNV@XjXHJVDN\\ERjL~CTEdAtHRCHbRhBhbZH\\E@RXBdLOad_dGtD`E\\D¬V|PtRnX`XrtZV|`¢XtZxbbdpRj|pxvf\\L^VpNLNT@^TbDbNTPRXNV\\TRdLVBlRJKPCdTDZKhTbXTRNVLCHWPCpFp\\pnNRpCZNb`fnLV\\VzJP\\TRdNCZJznBTHj@`JdRdZR``LFXZV`LDPZRLP@dPh`ZPjnhJhZ~ZdXhLDRTdrhBNCnHP`Rrd||VLP@zXdDhNJEp@vTjHhPz^zbXRfNfn^XT\\P`L`VjXTP^ff~~flLF|zjPPNvvv\\lb`p`zZvPtRTZFbXBRHbxJ\\LXZRRjH\\RJPhHDtHvB\\PdDdTrALTJZZHRFlALZFVNLX@ZNRHpFFB`NnCLTTZbPAPNHRDpBEFFCVLFARJHVE\\FV@pKjD`Ll\\X@bIGNG®phZtj~dnVpdrTTPZdR\\bfrXHFNTJJNbXRXjVXxRL|LRNBFZHFI\\MHHNF@VIDDE¦CLHV@HLAZJVAlOBFKAnJ\\ANT`dPN`BVJB¦¤VNVFL^"],
				"encodeOffsets": [
					[176351, -41753]
				]
			}
		}],
		"UTF8Encoding": true
	});
}));