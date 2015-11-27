﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SimpleIdentityServer.Api.Tests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("GetTokenViaAuthorizationCodeGrantType")]
    public partial class GetTokenViaAuthorizationCodeGrantTypeFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetTokenViaAuthorizationCodeGrantType.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetTokenViaAuthorizationCodeGrantType", "As an authenticated user\r\nI want to retrieve my access token and id_token via the" +
                    " authorization code workflow", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 5
#line 6
 testRunner.Given("a mobile application MyHolidays is defined", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
 testRunner.And("the redirection uri http://localhost is assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "IsInternal",
                        "Claims"});
            table1.AddRow(new string[] {
                        "openid",
                        "true",
                        ""});
            table1.AddRow(new string[] {
                        "PlanningApi",
                        "false",
                        ""});
            table1.AddRow(new string[] {
                        "profile",
                        "true",
                        "name"});
#line 8
 testRunner.And("the scopes are defined", ((string)(null)), table1, "And ");
#line 14
 testRunner.And("the id_token signature algorithm is set to none for the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("the scopes openid,profile,PlanningApi are assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("the client secret MyHolidays is assigned to the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("the grant-type authorization_code is supported by the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("the response-types code are supported by the client MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name"});
            table2.AddRow(new string[] {
                        "habarthierry@loki.be",
                        "thabart"});
#line 19
 testRunner.And("create a resource owner", ((string)(null)), table2, "And ");
#line 22
 testRunner.And("authenticate the resource owner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("the consent has been given by the resource owner habarthierry@loki.be for the cli" +
                    "ent MyHolidays and scopes openid,PlanningApi,profile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "scope",
                        "response_type",
                        "client_id",
                        "redirect_uri",
                        "prompt",
                        "state",
                        "nonce"});
            table3.AddRow(new string[] {
                        "openid PlanningApi profile",
                        "code",
                        "MyHolidays",
                        "http://localhost",
                        "none",
                        "state1",
                        "parameterNonce"});
#line 24
 testRunner.And("requesting an authorization code", ((string)(null)), table3, "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("request an id token and access token via the authorization grant type flow. The c" +
            "lient credentials are passed via client_secret_basic")]
        public virtual void RequestAnIdTokenAndAccessTokenViaTheAuthorizationGrantTypeFlow_TheClientCredentialsArePassedViaClient_Secret_Basic()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("request an id token and access token via the authorization grant type flow. The c" +
                    "lient credentials are passed via client_secret_basic", ((string[])(null)));
#line 29
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 30
 testRunner.Given("the token endpoint authentication method client_secret_basic is assigned to the c" +
                    "lient MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "grant_type",
                        "redirect_uri",
                        "client_id"});
            table4.AddRow(new string[] {
                        "authorization_code",
                        "http://localhost",
                        "MyHolidays"});
#line 31
 testRunner.When("requesting a token with basic client authentication for the client id MyHolidays " +
                    "and client secret MyHolidays", ((string)(null)), table4, "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "TokenType"});
            table5.AddRow(new string[] {
                        "Bearer"});
#line 35
 testRunner.Then("the following token is returned", ((string)(null)), table5, "Then ");
#line 38
 testRunner.And("decrypt the id_token parameter from the response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Alg"});
            table6.AddRow(new string[] {
                        "none"});
#line 39
 testRunner.And("the protected JWS header is returned", ((string)(null)), table6, "And ");
#line 42
 testRunner.And("the parameter nonce with value parameterNonce is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("the claim sub with value habarthierry@loki.be is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("request an id token and access token via the authorization grant type flow. The c" +
            "lient credentials are passed via client_secret_post method")]
        public virtual void RequestAnIdTokenAndAccessTokenViaTheAuthorizationGrantTypeFlow_TheClientCredentialsArePassedViaClient_Secret_PostMethod()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("request an id token and access token via the authorization grant type flow. The c" +
                    "lient credentials are passed via client_secret_post method", ((string[])(null)));
#line 46
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 47
 testRunner.Given("the token endpoint authentication method client_secret_post is assigned to the cl" +
                    "ient MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "grant_type",
                        "redirect_uri",
                        "client_id",
                        "client_secret"});
            table7.AddRow(new string[] {
                        "authorization_code",
                        "http://localhost",
                        "MyHolidays",
                        "MyHolidays"});
#line 48
 testRunner.When("requesting a token by using a client_secret_post authentication mechanism", ((string)(null)), table7, "When ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "TokenType"});
            table8.AddRow(new string[] {
                        "Bearer"});
#line 52
 testRunner.Then("the following token is returned", ((string)(null)), table8, "Then ");
#line 55
 testRunner.And("decrypt the id_token parameter from the response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Alg"});
            table9.AddRow(new string[] {
                        "none"});
#line 56
 testRunner.And("the protected JWS header is returned", ((string)(null)), table9, "And ");
#line 59
 testRunner.And("the parameter nonce with value parameterNonce is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("the claim sub with value habarthierry@loki.be is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("request an id token and access token via the authorization grant type flow. The c" +
            "lient credentials are passed via client_secret_jwt authentication method")]
        public virtual void RequestAnIdTokenAndAccessTokenViaTheAuthorizationGrantTypeFlow_TheClientCredentialsArePassedViaClient_Secret_JwtAuthenticationMethod()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("request an id token and access token via the authorization grant type flow. The c" +
                    "lient credentials are passed via client_secret_jwt authentication method", ((string[])(null)));
#line 63
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 64
 testRunner.Given("the token endpoint authentication method client_secret_jwt is assigned to the cli" +
                    "ent MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Kid",
                        "Alg",
                        "Operation",
                        "Kty",
                        "Use"});
            table10.AddRow(new string[] {
                        "1",
                        "RS256",
                        "Sign",
                        "RSA",
                        "Sig"});
            table10.AddRow(new string[] {
                        "2",
                        "RSA1_5",
                        "Encrypt",
                        "RSA",
                        "Enc"});
#line 65
 testRunner.And("add json web keys", ((string)(null)), table10, "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "grant_type",
                        "redirect_uri",
                        "client_assertion_type"});
            table11.AddRow(new string[] {
                        "authorization_code",
                        "http://localhost",
                        "urn:ietf:params:oauth:client-assertion-type:jwt-bearer"});
#line 69
 testRunner.And("create a request to retrieve a token", ((string)(null)), table11, "And ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "iss",
                        "sub",
                        "jti"});
            table12.AddRow(new string[] {
                        "MyHolidays",
                        "MyHolidays",
                        "1"});
#line 72
 testRunner.And("create the JWS payload", ((string)(null)), table12, "And ");
#line 75
 testRunner.And("assign audiences http://localhost/identity to the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("expiration time 300 in seconds to the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And("sign the jws payload with 1 kid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.And("encrypt the jws token with 2 kid, encryption algorithm A128CBC_HS256 and password" +
                    " MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And("set the client assertion value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.And("set the client id MyHolidays into the request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.When("retrieve token via client assertion authentication", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "TokenType"});
            table13.AddRow(new string[] {
                        "Bearer"});
#line 84
 testRunner.Then("the following token is returned", ((string)(null)), table13, "Then ");
#line 87
 testRunner.And("decrypt the id_token parameter from the response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Alg"});
            table14.AddRow(new string[] {
                        "none"});
#line 88
 testRunner.And("the protected JWS header is returned", ((string)(null)), table14, "And ");
#line 91
 testRunner.And("the parameter nonce with value parameterNonce is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And("the claim sub with value habarthierry@loki.be is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("request an id token and access token via the authorization grant type flow. The c" +
            "lient credentials are passed via private_key_jwt authentication method")]
        public virtual void RequestAnIdTokenAndAccessTokenViaTheAuthorizationGrantTypeFlow_TheClientCredentialsArePassedViaPrivate_Key_JwtAuthenticationMethod()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("request an id token and access token via the authorization grant type flow. The c" +
                    "lient credentials are passed via private_key_jwt authentication method", ((string[])(null)));
#line 95
this.ScenarioSetup(scenarioInfo);
#line 5
this.FeatureBackground();
#line 96
 testRunner.Given("the token endpoint authentication method private_key_jwt is assigned to the clien" +
                    "t MyHolidays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Kid",
                        "Alg",
                        "Operation",
                        "Kty",
                        "Use"});
            table15.AddRow(new string[] {
                        "1",
                        "RS256",
                        "Sign",
                        "RSA",
                        "Sig"});
#line 97
 testRunner.And("add json web keys", ((string)(null)), table15, "And ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "grant_type",
                        "redirect_uri",
                        "client_assertion_type"});
            table16.AddRow(new string[] {
                        "authorization_code",
                        "http://localhost",
                        "urn:ietf:params:oauth:client-assertion-type:jwt-bearer"});
#line 100
 testRunner.And("create a request to retrieve a token", ((string)(null)), table16, "And ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "iss",
                        "sub",
                        "jti"});
            table17.AddRow(new string[] {
                        "MyHolidays",
                        "MyHolidays",
                        "1"});
#line 103
 testRunner.And("create the JWS payload", ((string)(null)), table17, "And ");
#line 106
 testRunner.And("assign audiences http://localhost/identity to the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
 testRunner.And("expiration time 300 in seconds to the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.And("sign the jws payload with 1 kid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
 testRunner.And("set the client assertion value", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
 testRunner.When("retrieve token via client assertion authentication", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "TokenType"});
            table18.AddRow(new string[] {
                        "Bearer"});
#line 113
 testRunner.Then("the following token is returned", ((string)(null)), table18, "Then ");
#line 116
 testRunner.And("decrypt the id_token parameter from the response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "Alg"});
            table19.AddRow(new string[] {
                        "none"});
#line 117
 testRunner.And("the protected JWS header is returned", ((string)(null)), table19, "And ");
#line 120
 testRunner.And("the parameter nonce with value parameterNonce is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
 testRunner.And("the claim sub with value habarthierry@loki.be is returned by the JWS payload", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
